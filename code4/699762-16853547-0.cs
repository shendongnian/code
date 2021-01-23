    class Program
    {
        private static string starting =
            "<xmlreport title=\"ABC: TEST Most Saved2\" dates=\"Week of May 19,2013\"><columns><column name=\"Page\" type=\"dimension\">Page</column><column name=\"Events\" type=\"metric\" hastotals=\"true\">Events</column></columns><rows><row rownum=\"1\"><cell columnname=\"page\" csv=\"http://www.ABC.com/profile/recipebox\">http://www.ABC.com/profile/recipebox</cell><cell columnname=\"events\" percentage=\"0.1%\">489</cell></row><row rownum=\"2\"><cell columnname=\"page\" csv=\"http://www.ABC.com/recipes/peanut-butter-truffle-brownies/c5c602e4-007b-43e0-aaab-2f9aed89524c\">http://www.ABC.com/recipes/peanut-butter-truffle-brownies/c5c602e4-007b-43e0-aaab-2f9aed89524c</cell><cell columnname=\"events\" percentage=\"0.0%\">380</cell></row></rows><totals><pagetotals><total columnname=\"events\" value=\"1820.00000\">1,820 (0.2%)</total></pagetotals><reporttotals><total columnname=\"events\" value=\"7838.000000\">7,838 (0.8%)</total></reporttotals><timeperiodtotals><total columnname=\"events\" value=\"955774.000000\">955,774 (100.0%)</total></timeperiodtotals></totals></xmlreport>";
        static void Main(string[] args)
        {
            // parse from xml to objects
            StringReader reader = new StringReader(starting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlReport));
            var xmlreport = (XmlReport)xmlSerializer.Deserialize(reader);
            
            // todo: do some process mapping ...
            // parse out as json
            var json = JsonConvert.SerializeObject(xmlreport);
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
    [Serializable]
    [XmlRoot(ElementName = "xmlreport")]
    public class XmlReport
    {
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "dates")]
        public string Dates { get; set; }
        [XmlArray(ElementName = "columns")]
        [XmlArrayItem(typeof(Column), ElementName = "column")]
        public Collection<Column> Columns { get; set; }
    }
    [Serializable]
    public class Column
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
