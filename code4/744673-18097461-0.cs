    class Program
    {
        static void Main(string[] args)
        {
            var singleElement = false;
            var x = XDocument
                .Parse(@"<Root><Student key=""Student1"" value=""4""/></Root>");
            if (x.Root.Elements().Count() == 1)
            {
                singleElement = true;
                var single = x.Root.Elements().First();
                x.Root.Elements().First().AddAfterSelf(single);
                x.Root.Elements().Last().Attributes().ToList()
                    .ForEach(a => a.Remove());
            }
            var xml = JsonConvert.SerializeXNode(x);
            if (singleElement)
                xml = xml.Replace(",null", "");
        }
    }
