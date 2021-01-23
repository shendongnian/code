    static void Main(string[] args)
    {
        string rootPath = Console.ReadLine();
        var dir = new DirectoryInfo(rootPath);
        var doc = new XDocument(GetDirectoryXml(dir));
        Console.WriteLine(doc.ToString());
        Console.Read();
    }
