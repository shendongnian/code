    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace TempSandbox
    {
        [XmlRoot]
        public class Catalog
        {
            [XmlElement("Adventurer")]
            public List<Adventurer> Adventurers;
    
            private readonly static Type[] myTypes = new Type[] { typeof(Adventurer), typeof(Gear), typeof(Item) };
            private readonly static XmlSerializer mySerializer = new XmlSerializer(typeof(Catalog), myTypes);
    
            public static Catalog Deserialize(string xml)
            {
                return (Catalog)Utils.Deserialize(mySerializer, xml, Encoding.UTF8);
            }
        }
    
        [XmlRoot]
        public class Adventurer
        {
            public int ID;
    
            public string Name;
    
            public string Address;
    
            public string Phone;
    
            [XmlElement(IsNullable = true)]
            public Gear Gear;
        }
    
        [XmlRoot]
        public class Gear
        {
            public List<Item> Attack;
    
            public List<Item> Defense;
        }
    
        [XmlRoot]
        public class Item
        {
            public string IName;
    
            public decimal IPrice;
        }
    }
