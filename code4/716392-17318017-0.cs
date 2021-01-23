    using System;
    using System.Xml.Serialization;
    using System.IO;
    namespace Test
    {
    [Serializable]
    [XmlRoot("DocumentElement")]
    public class Documentelement
    {
        [XmlElement]
        public PartInfo[] PartInfo { get; set; }
    }
    public class PartInfo
    {
        [XmlElement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string PartNo { get; set; }
        public int SerialNo { get; set; }
        public string Parameter { get; set; }        
        public DateTime InstallDate { get; set; }
        public DateTime InstallTill { get; set; }
    }
    public class Test
    {
        private PartInfo details_1()
        {
            PartInfo details = new PartInfo
            {
                ID = 0,
                Name = "QVR",
                PartNo = "A11",
                SerialNo = 453,
                Parameter = "C -11",
                // This you should add as date time,  I just used the string to parse your time that you showed in your example.
                InstallDate = DateTime.Parse("2013-02-04T17:16:56.383+05:30"),
                InstallTill = DateTime.Parse("2013-02-15T17:16:56.3830837+05:30")
            };
            return details;
        }
        private PartInfo details_2()
        {
            PartInfo details = new PartInfo
            {
                ID = 1,
                Name = "EAFR",
                PartNo = "B07",
                SerialNo = 32,
                Parameter = "B-16",
                // This you should add as date time,  I just used the string to parse your time that you showed in your example.
                InstallDate = DateTime.Parse("2013-02-18T17:17:44.589+05:30"),
                InstallTill = DateTime.Parse("2013-02-28T17:17:44.589+05:30")
            };
            return details;
        }
        public void setXmlValues()
        {            
            Documentelement testOut = new Documentelement { PartInfo = new[] { details_1(), details_2() }};
            xml_serialise(testOut);
            Documentelement testIn = xml_deserialise();
            int val = testIn.PartInfo[0].ID;
            DateTime dt = testIn.PartInfo[0].InstallDate;
            string shortTime = dt.ToShortTimeString();
        }
        private void xml_serialise(Documentelement test)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Documentelement));
            using (TextWriter writer = new StreamWriter("test.xml"))
            {
                ser.Serialize(writer, test);
            }
        }
        private Documentelement xml_deserialise()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Documentelement));
            Documentelement test;
            using (TextReader writer = new StreamReader("test.xml"))
            {
                test = (Documentelement)ser.Deserialize(writer);
            }
            return test;
        }
    }
    }
