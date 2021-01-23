    List<Result> results = new List<Result>();
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Result>), new XmlRootAttribute("results"));
    using (FileStream stream = new FileStream(@"C:\Test.xml", FileMode.Open))
    {
        results = (List<Result>)xmlSerializer.Deserialize(stream);
    }
