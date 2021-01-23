    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Myclassdef>();
            var query = XDocument
                .Parse("<Query><ElementPath> Shippers</ElementPath></Query>");
            var doc = XDocument.Parse(File.ReadAllText("xml.xml"));
            doc.Descendants(
                XName.Get(
                        query.Root.Value.Trim(),
                        doc.Root.GetDefaultNamespace().NamespaceName))
                .ToList()
                .ForEach(e =>
                {
                    var data = new Myclassdef();
                    data.Data = e
                        .Elements()
                        .Select(c => new
                        {
                            Name = c.Name.LocalName,
                            Value = (object)c.Value
                        })
                        .ToDictionary(c => c.Name, c => c.Value);
                    list.Add(data);
                });
        }
    }
