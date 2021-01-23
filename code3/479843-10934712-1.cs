    using (var ms = new MemoryStream())
    {
        var sw = new StreamWriter(ms);
        var sr = new StreamReader(ms);
        sw.WriteLine("data");
        sw.WriteLine("data 2");
        ms.Position = 0;
        Console.WriteLine(sr.ReadToEnd());                        
    }
