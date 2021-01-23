    class Program
    {
        static void Main(string[] args)
        {
            String xmlString = @"<select>
            <option value=""2"" ID=""451"">Some other text</option>
            <option value=""5"" ID=""005"">Some other text</option>
            <option value=""6"" ID=""454"">Some other text</option>
            <option value=""15"" ID=""015"">Some other text</option>
            <option value=""17"" ID=""47"">Some other text</option>
            </select>";
            Dictionary<string, string> theDict = new Dictionary<string, string>();
            theDict.Add("451", "Dict Val 1");
            theDict.Add("005", "Dict Val 2");
            theDict.Add("454", "Dict Val 3");
            theDict.Add("015", "Dict Val 4");
            theDict.Add("47", "Dict Val 5");
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "option")
                            {
                                System.Diagnostics.Debug.WriteLine(String.Format("ID: {0} \nValue: {1} \nDictValue: {2}", reader.GetAttribute("ID"), reader.GetAttribute("value"), theDict[reader.GetAttribute("ID")]));
                            }
                            break;
                    }
                }
            }
        }
    }
