        [Test]
        public void Test()
        {
            XElement root = XElement.Load(@"C:\Data.xml");
            XElement person = FindByName(root, "sara");
            if (person == null)
            {
                return;
            }
            Console.WriteLine("Name: {0}, Age: {1}, Gender: {2}",
                              person.Element("name").Value,
                              person.Element("age").Value,
                              person.Element("age").Value);
        }
        private static XElement FindByName(XContainer root, string name)
        {
            return root.Descendants()
                .Where(x => x.Name.LocalName == "name" && x.Value == name)
                .Select(x => x.Parent)
                .FirstOrDefault();
        }
