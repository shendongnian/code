    const string lineToFind = "blah-blah";
    var fileNames = Directory.GetFiles(@"C:\path\here");
    foreach (var fileName in fileNames)
    {   
        int line = 1;     
        using (var reader = new StreamReader(fileName))
        {
             // read file line by line 
             string lineRead;
             while ((lineRead = reader.ReadLine()) != null)
             {
                 if (lineRead == lineToFind)
                 {
                     Console.WriteLine("File {0}, line: {1}", fileName, line);
                 }
                 line++;
             }
        }
    }
