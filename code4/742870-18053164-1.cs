    class Program
    {
        const string
            MinOccurs = "minOccurs",
            Element = "element",
            LocalName = "xs";
        static void Main(string[] args)
        {
            String parameter =
                @"<HostName>Arasanalu</HostName>
                  <AdminUserName>Administrator</AdminUserName>
                  <AdminPassword>A1234</AdminPassword>
                  <PlaceNumber>38</PlaceNumber>";
            var ds = new DataSet();
            ds.ReadXml(new StringReader("<root>" + parameter + "</root>"));
            var sb = new StringBuilder();
            using (var w = new StringWriter(sb))
            {
                ds.WriteXmlSchema(w);
            
            var doc = XDocument.Parse(sb.ToString());
            doc.Root.LastNode.Remove();
            doc.Root.Attributes()
                .Where(a => a.Name.LocalName != LocalName).Remove();
            doc.Descendants(XName.Get(Element, 
                doc.Root.GetNamespaceOfPrefix(LocalName).NamespaceName))
                .ToList()
                .ForEach(e =>
                {
                    var minOccurs = e.Attribute(XName.Get(MinOccurs));
                    if (minOccurs != null)
                        minOccurs.Remove();
                });
            sb.Clear();
            doc.Save(w);
            Console.WriteLine(sb.ToString());
            }
        }
    }
