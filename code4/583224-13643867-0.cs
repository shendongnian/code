    class Program
    {
        static void Main(string[] args)
        {
            const string xml = @"<items>
                              <item id='1' desc='one'>
                                <itemBody date='2012-11-12' />
                              </item>
                              <item id='2' desc='two'>
                                <itemBody date='2012-11-13' />
                              </item>
                              <item id='3' desc='three'>
                                <itemBody date='2012-11-14' />
                              </item>
                              <item id='4' desc='four'>
                                <itemBody date='2012-11-15' />
                              </item>
                            </items>";
            var xmlReader = XmlReader.Create(new StringReader(xml));
            XElement element = XElement.Load(xmlReader, LoadOptions.SetBaseUri);
            IEnumerable<XElement> items = element.DescendantsAndSelf("item");
            foreach (var xElement in items)
            {
                string id = GetAttributeValue("id", xElement);
                string desc = GetAttributeValue("desc", xElement);
                string itemBody = GetElementValue("itemBody", "date", xElement);
                Console.WriteLine("id = {0}, desc = {1}, date = {2}", id, desc, itemBody);
            }
            Console.ReadLine();
        }
        private static string GetElementValue(string elementName, string attributeName, XElement element)
        {
            XElement xElement = element.Element(elementName);
            string value = string.Empty;
            if (xElement != null)
            {
                XAttribute xAttribute = xElement.Attribute(attributeName);
                if (xAttribute != null)
                {
                    value = xAttribute.Value;
                }
            }
            return value;
        }
        private static string GetAttributeValue(string attributeName, XElement element)
        {
            XAttribute xAttribute = element.Attribute(attributeName);
            string value = string.Empty;
            if (xAttribute != null)
            {
                value = xAttribute.Value;
            }
            return value;
        }
    }
