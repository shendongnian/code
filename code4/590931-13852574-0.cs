    public static void WriteToFile(string[] linesContent, string fileLocation) //Creates a void of name WriteToFile(string[] linesContent, string fileLocation) where linesContent are the lines to write and fileLocation is the target file path to write to
    {
        StreamWriter _writer = new StreamWriter(fileLocation); //Initialize a new StreamWriter of name _writer to write to fileLocation
        foreach (string s in linesContent) //Get s as a string for every string in linesContent
        {
            _writer.WriteLine(s); //Write s in a new line to the file
        }
        _writer.Close(); //Close the writer
    }
    public static void SortFile(string fileLocation) //Creates a void of name SortFile(string fileLocation) where fileLocation is the path of the file to sort alphabetically
    { 
        string[] Lines = File.ReadAllLines(fileLocation, Encoding.UTF8); //Initializes a string array of name Lines as the content of the file splitted by Environment.NewLine
        Array.Sort(Lines); //Sorts the string array of name Lines
        WriteToFile(Lines, fileLocation); //Writes Lines to the file
    }
    static void Main() //Our main entry point
    {
        string fileLocation = @"D:\Resources\myfile.txt"; //Initializes a new string of name fileLocation as D:\Resources\myfile.txt
        WriteToFile(new string[] { "my third line", "this is my second line", "and this is my first line" }, fileLocation); //Writes the three lines provided to fileLocation
        SortFile(fileLocation); //Sorts fileLocation
    }
