    public class Program
    {
        static void Main()
        {
            XNamespace nsA = "http://MyURLA";
            XNamespace nsB = "http://MyURLB";
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(
                    nsB + "value",
                    new XAttribute(XNamespace.Xmlns + "XXXX", nsA),
                    new XAttribute("attributeA", "A"),
                    new XAttribute("attributeB", "B"),
                    new XElement("FieldA", "AAAA"),
                    new XElement("FieldA", "BBBB"),
                    new XElement("FieldC", "CCCC"),
                    new XElement(
                        "status", 
                        new XAttribute("attributeC", "C"),
                        new XElement("FieldC", "ValueFieldC")
                    ),
                    new XElement(
                        "LastUpdate", 
                        new XAttribute("date", DateTime.Now), 
                        new XAttribute("login", "testing")
                    ),
                    new XElement(
                        nsA + "Infos",
                        new XElement(nsA + "InfoA", false),
                        new XElement(nsA + "InfoB", false)
                    )
                )
            );
            Console.WriteLine(doc.ToString());
        }
    }
