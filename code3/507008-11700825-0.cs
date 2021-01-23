        [Test]
        public void Test()
        {
            XElement root = XElement.Load("Data.xml");
            root.Descendants()
               .Where(x => x.Name.LocalName == "displayDateTime")
               .ToList()
               .ForEach(x => x.ReplaceNodes(GetDate(x)));
        }
        private static DateTime GetDate(XElement element)
        {
             return DateTime.Today.Add(DateTime.Parse(element.Value).TimeOfDay);
        }
