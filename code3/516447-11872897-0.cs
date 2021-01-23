        [Test]
        public void Test()
        {
            XElement root = XElement.Load(@"C:\1.xml");
            XElement identifier = GetIdentifierByName(root, "CompanyPolicyId");
            if (identifier == null)
            {
                return;
            }
            Console.WriteLine(identifier.Attribute("value"));
        }
        private static XElement GetIdentifierByName(XContainer root, string name)
        {
            return root.Descendants()
                .Where(x => x.Name.LocalName == "Identifier")
                .FirstOrDefault(x => x.Attribute("name").Value == name);
        }
    }
