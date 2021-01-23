    class ListFileToXmlConverter
    {
        private class Entry
        {
            public string Application { get; set; }
            public string Product { get; set; }
            public string Config { get; set; }
            public string Value { get; set; }
        }
        private IEnumerable<Entry> LoadEntries(string filename)
        {
            return File.ReadAllLines(filename)
                .Where(line => !String.IsNullOrWhiteSpace(line))
                .Select(line => line.Split(new[] {'\t'}))
                .Select(split => new Entry
                    {
                        Product = split[0],
                        Application = split[1],
                        Config = split[2],
                        Value = split[3]
                    });
        }
        public XElement ConvertToXml(string filename)
        {
            return new XElement("root",
                LoadEntries(filename)
                    .GroupBy(entry => entry.Application)
                    .Select(grouping =>
                        new XElement(
                            "Application",
                            new XAttribute("Name", grouping.Key),
                            grouping
                                .GroupBy(entry => entry.Product)
                                .Select(grouping2 =>
                                    new XElement(
                                        "Product",
                                        new XAttribute("Name", grouping2.Key),
                                        grouping2.Select(entry =>
                                            new XElement("Config",
                                                new XAttribute("Name", entry.Config),
                                                entry.Value)
                                            )
                                        )
                                )
                            )
                    )
                );
        }
    }
