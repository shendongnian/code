    static void Main(string[] args)
            {
                var f = XElement.Parse("<root><Document><Tests><Test Type=\"Failure\"><Groups><Group><Name>Name 123</Name></Group></Groups></Test></Tests></Document></root>");
    
                var names =
                    f.Descendants("Test").Where(t => t.Attribute("Type").Value == "Failure").Descendants("Group").Select(
                        g => g.Element("Name").Value);
    
                foreach (var name in names)
                {
                    Console.WriteLine(name);    
                }
            }
