    static void Main(string[] args)
    {
        Console.WriteLine("Initiating test!");
        XmlSerializer serializer = new XmlSerializer(typeof(DelayedQuotes));
        FileStream xmlFile = new FileStream("testXml.xml", FileMode.Open);
        DelayedQuotes quotes = (DelayedQuotes) serializer.Deserialize(xmlFile);
        Console.WriteLine("Finalizing test!");
    }
