    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                GameObjects a = new GameObjects();
                ChestPlate b = new ChestPlate();
                List<GameObjects> d = new List<GameObjects>();
                b.SerializeToXML(d);
                Console.ReadLine();
            }
    
        }
    
        [Serializable]
        public class GameObjects
        {
            //Defines name within XML file:
            [XmlElement("Item_ID")]
            public int Item_ID { get; set; }
            [XmlElement("Item_Name")]
            public string Item_Name = "bob";
            [XmlElement("Item_type")]
            public string Item_type = "GameObject";
            [XmlElement("Item_Level")]
            public int Item_Level = 5;
            [XmlElement("Item_description")]
            public string Item_description = "best description evar";
    
            public GameObjects(int id, string name, string type, int level, string description)
            {
                this.Item_ID = id;
                this.Item_Name = name;
                this.Item_type = type;
                this.Item_Level = level;
                this.Item_description = description;
            }
    
            public GameObjects()
            {
    
            }
    
        }
    
        [Serializable]
        [XmlInclude(typeof(GameObjects))]
        public class GameObjectData
        {
            [XmlArrayItem(typeof(GameObjects))]
            public List<GameObjects> GameList { get; set; }
    
    
        }
    
        public class ChestPlate : GameObjects
        {
            [XmlElement("Armour_Rating")]
            int Armour_Rating = 5;
    
            public ChestPlate(int Armour_id, string Armour_name, string Armour_type, int Armour_level, string Armour_description)
                : base(Armour_id, Armour_name, Armour_type, Armour_level, Armour_description)
            {
                this.Item_ID = Armour_id;
                this.Item_Name = Armour_name;
                this.Item_type = Armour_type;
                this.Item_Level = Armour_level;
                this.Item_description = Armour_description;
            }
    
            public ChestPlate()
            {
    
    
            }
    
    
            public void SerializeToXML(List<GameObjects> responsedata)
            {
                GameObjectData f = new GameObjectData();
                f.GameList = new List<GameObjects>();
                f.GameList.Add(new GameObjects { Item_ID = 1234, Item_Name = "OMG", Item_type = "CHESTPLATE", Item_Level = 5, Item_description = "omg" });
    
    
                XmlSerializer serializer = new XmlSerializer(typeof(GameObjectData));
                TextWriter textWriter = new StreamWriter(@".\Test.xml");
    
                serializer.Serialize(textWriter, f);
    
                Console.WriteLine(f);
            }
        }
    }
