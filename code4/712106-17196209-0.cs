    using(StreamReader OpenFile = new System.IO.StreamReader(file.FileName))
    {
        string textLine = string.Empty;
        while((textLine = OpenFile.ReadLine()) != null)
            ExecuteLine(textLine);
    }
    
    private void ExecuteLine(string line)
    {
            Regex Gcode = new Regex("[ngxyzf][+-]?[0-9]*\\.?[0-9]*", RegexOptions.IgnoreCase);
            MatchCollection m = Gcode.Matches(line);
            ....
    }
