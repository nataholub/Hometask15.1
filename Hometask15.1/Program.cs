Console.Write("Enter the path to the source file: ");
string sourcePath = Console.ReadLine();

Console.Write("Enter the path to the file where the data should be copied: ");
string destinationPath = Console.ReadLine();

try
{   
    if (!File.Exists(sourcePath))
    {
        Console.WriteLine("Error! Source file not found.");
        return;
    }

    if (File.Exists(destinationPath))
    {
        Console.Write("The file already exists. Overwrite it? (y/n): ");
        string answer = Console.ReadLine();

        if (answer == "n")
        {
            Console.WriteLine("Operation canceled by user.");
            return;
        }
        else if (answer != "y")
        {
            Console.WriteLine("Unknown operation.");
            return;
        }
    }
    
    string content = File.ReadAllText(sourcePath);
    File.WriteAllText(destinationPath, content);

    Console.WriteLine("Copy completed successfully!");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Access error: check the file permissions.");
}
catch (IOException ex)
{
    Console.WriteLine($"Input/output error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}