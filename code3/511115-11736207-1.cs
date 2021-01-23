    Boolean writeHeader = (!File.Exists(fileName));
    
    using (StreamWriter file = new System.IO.StreamWriter(fileName, true))
    {
        if (writeHeader)
        {
           file.WriteLine(headerLine);
        }
    
        file.WriteLine(line);
        file.Close();
    }
