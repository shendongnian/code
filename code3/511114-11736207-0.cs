    Boolean writeHeader = (!File.Exists(fileName));
    
    System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true);
    
    if (writeHeader)
    {
       file.WriteLine(headerLine);
    }
    
    file.WriteLine(line);
    file.Close();
