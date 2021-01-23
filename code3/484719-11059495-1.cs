    var fileNames = Directory.GetFiles(@"C:\path\here");
    foreach (var fileName in fileNames)
    {        
        using (var fileStream = new FileStream(fileName, ...))
        {
             var reader = new StreamReader(fileStream);
             // Read the first line of the file
             string line = reader.ReadLine();
             while(line != null)
             {
                 // process the current line here...
                 
                 // Read the next line
                 line = reader.ReadLine();
             }    
        }
    }
