    static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(xmlFile);
                IEnumerable<XElement> rows = from row in doc.Descendants("x")
                                             where row.Attribute("a1").ToString() == "abc" & row.Attribute("a2").ToString() == "xyz"
                                             select row;
                int first;
                int second;
                int third;
                foreach (XElement ele in rows)
                {
                    Int32.TryParse(ele.Attribute("a3").Value, out first);
                    Int32.TryParse(ele.Attribute("a4").Value, out second);
                    Int32.TryParse(ele.Attribute("a5").Value, out third);
                    Console.WriteLine(string.Format("{0} {1} {2}", first, second, third);
                }
            }
        }
    }
