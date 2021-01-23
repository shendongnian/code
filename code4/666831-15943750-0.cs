    static class Program
    {
        static void Main()
        {
            var ser = new XmlSerializer(typeof(SpreadResultData));
            SpreadResultData data;
            using(var file = File.OpenRead("my.xml"))
            {
                data = (SpreadResultData)ser.Deserialize(file);
            }
        }
    }
    public class SpreadResultData
    {
        public List<Spread> SpreadToList {get;set;}
    }
    public class Spread
    {
        public string GroupName { get; set; }
        public string CellPos { get; set; }
        public string CellValue { get; set; }
        public string Color { get; set; }
        public int CellLinePos { get; set; }
        public bool IsSetColor { get; set; }
        public bool IsClear { get; set; }
    }
