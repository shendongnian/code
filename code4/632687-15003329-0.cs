    var fs = File.OpenRead(@"C:\myxml.xml");
    var reader = new StreamReader(fs);
    DoSomething(reader);
    
    static void DoSomething(TextReader reader)
    {
        var streamReader = reader as StreamReader;
        if (streamReader != null)
        {
            var fileStream = streamReader.BaseStream as FileStream;
            if (fileStream != null)
                Console.WriteLine(fileStream.Name);
            else { /* No filename */ }
        }
        else { /* No filename */ }
        // ...
    }
