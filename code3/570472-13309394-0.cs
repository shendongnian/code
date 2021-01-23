    class Testtypes
    {
        public string Type { get; private set; }
        public static List<Testtypes> FromXml(string filename)
        {
            return XDocument.Parse(filename)
                            .Descendants("Type")
                            .Select(x => new Testtypes { Type = x.Value })
                            .ToList();
        }
    }
