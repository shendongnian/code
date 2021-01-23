    public class StackOverflow_15441384
    {
        const string XML = @"<StartLot>
                                   <fileCreationDate level=""7"">201301132210</fileCreationDate>
                                   <fmtVersion level=""7"">3.0</fmtVersion>
                                </StartLot>";
        public class StartLot
        {
            [XmlElement("fileCreationDate")]
            public LevelAndValue FileCreationDate { get; set; }
            [XmlElement("fmtVersion")]
            public LevelAndValue FmtVersion { get; set; }
        }
        public class LevelAndValue
        {
            [XmlAttribute("level")]
            public string Level { get; set; }
            [XmlText]
            public string Value { get; set; }
        }
        public static void Test()
        {
            XmlSerializer xs = new XmlSerializer(typeof(StartLot));
            StartLot sl = (StartLot)xs.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(XML)));
            Console.WriteLine("FCD.L = {0}", sl.FileCreationDate.Level);
            Console.WriteLine("FCD.V = {0}", sl.FileCreationDate.Value);
            Console.WriteLine("FV.L = {0}", sl.FmtVersion.Level);
            Console.WriteLine("FV.V = {0}", sl.FmtVersion.Value);
        }
    }
