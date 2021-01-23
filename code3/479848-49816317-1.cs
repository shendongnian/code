    using (var ms = new MemoryStream())
    {
        using (var sw = new StreamWriter(ms, Encoding.UTF8, 1024, true))
        {
            sw.WriteLine("data");
            sw.WriteLine("data 2");    
        }
        ms.Position = 0;
        using (var sr = new StreamReader(ms))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
