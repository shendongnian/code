            Dictionary<int, List<string>> countries = new Dictionary<int, List<string>>();
            XmlReader xml = XmlReader.Create("file://D:/Development/Test/StackOverflowQuestion/StackOverflowQuestion/Countries.xml");
            string language = null;
            string elementName = null;
            while (xml.Read())
            {
                switch (xml.NodeType)
                {
                    case XmlNodeType.Element:
                        elementName = xml.Name;
                        break;
                    case XmlNodeType.Text:
                        if (elementName == "name") language = xml.Value;
                        if (elementName == "country")
                        {
                            int country;
                            if (int.TryParse(xml.Value, out country))
                            {
                                List<string> languages;
                                if (!countries.TryGetValue(country, out languages))
                                {
                                    languages = new List<string>();
                                    countries.Add(country, languages);
                                }
                                languages.Add(language);
                            }
                        }
                        break;
                }
            }
            using (StreamWriter result = new StreamWriter(@"D:\Development\Test\StackOverflowQuestion\StackOverflowQuestion\Output.txt"))
            {
                xml = XmlReader.Create("file://D:/Development/Test/StackOverflowQuestion/StackOverflowQuestion/Products.xml");
                string product = null;
                elementName = null;
                HashSet<string> languages = new HashSet<string>();
                while (xml.Read())
                {
                    switch (xml.NodeType)
                    {
                        case XmlNodeType.Element:
                            elementName = xml.Name;
                            break;
                        case XmlNodeType.Text:
                            if (elementName == "name")
                            {
                                if (product != null && languages != null)
                                {
                                    result.Write(product);
                                    result.Write(" -> ");
                                    result.WriteLine(string.Join(", ", languages.ToArray()));
                                    languages.Clear();
                                }
                                product = xml.Value;
                            }
                            if (elementName == "country")
                            {
                                int country;
                                if (int.TryParse(xml.Value, out country))
                                {
                                    List<string> countryLanguages;
                                    if (countries.TryGetValue(country, out countryLanguages))
                                        foreach (string countryLanguage in countryLanguages) languages.Add(countryLanguage);
                                }
                            }
                            break;
                    }
                }
            }
        }
