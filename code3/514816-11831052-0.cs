    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Xml.Linq;
    
    namespace SO.XmlSqlServer
    {
        class Program
        {
            static void Main(string[] args)
            {
                var node = new SqlOutput
                {
                    NodeId = 28,
                    AccountNumber = 0,
                    AddressLine1 = "15 CANCUN ST",
                    SerialNo = 112156544,
                    XLatitude = 25.23456354,
                    YLongitude = -97.54435453,
                    Alarms = new List<Alarm>(new[]
                    {
                        new Alarm
                        {
                            AlarmId="Outage",
                            AlarmTime=DateTime.Now
                        },
                        new Alarm
                        {
                            AlarmId="Restore",
                            AlarmTime=DateTime.Now
                        }
                    })
                };
    
                XmlSerializer ser = new XmlSerializer(typeof(SqlOutput));
                XDocument doc = new XDocument();
                using (var writer = doc.CreateWriter())
                {
                    ser.Serialize(writer, node);
                }
                Console.WriteLine(doc.ToString());
                Console.ReadLine();
            }
        }
    
        [XmlRoot("node")]
        public class SqlOutput
        {
            [XmlElement("nodeid")]
            public int NodeId { get; set; }
    
            [XmlElement("account_no")]
            public int AccountNumber { get; set; }
    
            [XmlElement("address1")]
            public string AddressLine1 { get; set; }
    
            [XmlElement("serial_no")]
            public int SerialNo { get; set; }
    
            [XmlElement("x_lat")]
            public double XLatitude { get; set; }
    
            [XmlElement("y_lon")]
            public double YLongitude { get; set; }
    
            [XmlElement("alarm")]
            public List<Alarm> Alarms { get; set; }
        }
    
        public class Alarm
        {
            public string AlarmId { get; set; }
            public DateTime AlarmTime { get; set; }
        }
            
    }
