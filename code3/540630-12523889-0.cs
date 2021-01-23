    static void Main()
    {
        SecondXml();
    }
    public static string FirstXml()
    {
        string[] names = { "John", "Mohammed", "Marc", "Tamara", "joy" };
        var sw = new StringWriter();
        var xtw = new XmlTextWriter(sw);
        xtw.WriteStartDocument();
        xtw.WriteStartElement("root");
        foreach (string s in names)
        {
            xtw.WriteStartElement(s);
            xtw.WriteEndElement();
        }
        xtw.WriteEndElement();
        xtw.WriteEndDocument();
            
        return sw.ToString();
    }
    public static void SecondXml()
    {
        string secondXml = File.ReadAllText(@"t:\something.xml");
        string firstXml = FirstXml();
            
        Console.WriteLine("Comparing...");
        string result = GenerateDiffGram(firstXml, secondXml);
        Console.WriteLine(result);
        Console.WriteLine();
        Console.WriteLine("Finished compare");
        Console.Out.Write(firstXml);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(secondXml);
    }
    public static string GenerateDiffGram(string originalFile, string finalFile)
    {
        var xmldiff = new XmlDiff();
        var r1 = XmlReader.Create(new StringReader(originalFile));
        var r2 = XmlReader.Create(new StringReader(finalFile));
        var sw = new StringWriter();
        var xw = new XmlTextWriter(sw) {Formatting = Formatting.Indented};
        bool bIdentical = xmldiff.Compare(r1, r2, xw);
        Console.WriteLine();
        Console.WriteLine("bIdentical: " + bIdentical);
        return sw.ToString();
    }
