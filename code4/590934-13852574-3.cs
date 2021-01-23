    public static void SortFile(string fileLocation) //Creates a void of name SortFile(string fileLocation) where fileLocation is the path of the file to sort alphabetically
    { 
        StreamReader _reader = new StreamReader(fileLocation); //Initializes a new StreamReader of name _reader to read from fileLocation
    
        string fileContents = _reader.ReadToEnd(); //Initializes a new string of name fileContents which is the file content 
        string[] Lines = fileContents.Split(Environment.NewLine.ToCharArray()[0]); //Initializes a string array which is the output of splitting fileContents by a line
    
        Array.Sort(Lines); //Sorts the string array of name Lines
        _reader.Close(); //Closes the StreamReader so that the file can be accessible once again
        WriteToFile(Lines, fileLocation); //Writes Lines to the file
    }
