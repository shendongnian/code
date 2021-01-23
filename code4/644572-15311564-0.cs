    internal class Program
        {
            private static void Main(string[] args)
            {
                ItemBag item = new ItemBag()
                {
                    Bag = new Bag
                    {
                        BagConfig = new BagConfig { AncientRate = 1, ZenDrop = 1, ExcRate = 1, ItemRate = 1, Name = "ss", SocketRate = 1 }
                    },
                    Default = new Default
                    {
                        DefaultConfig = new DefaultConfig { Addopt = 1, Anc = 1, Category = 1, Exc = 1, ID = 1, Luck = 1, MaxLevel = 1, MinLevel = 1, Skill = 1, Sock = 1 }
                    },
                    Items = new List<Item>()
                    {
                        { new Item { Addopt = 1, Anc = 1, Category = 1, Exc = 1, ID = 1, Luck = 1, MaxLevel = 1, MinLevel = 1, Skill = 1, Sock = 1 }}
                    }
                };
    
                string serialized = item.XmlSerialize();
    
                Console.WriteLine(serialized);
                Console.ReadLine();
            }
        }
    
        [XmlRoot]
        public class ItemBag
        {
            public Bag Bag { get; set; }
    
            public Default Default { get; set; }
    
            [XmlArray("Items")]
            [XmlArrayItem("Item")]
            public List<Item> Items { get; set; }
    
            public ItemBag()
            {
                Bag = new Bag();
                Default = new Default();
                Items = new List<Item>();
            }
        }
    
        public class Bag
        {
            public BagConfig BagConfig { get; set; }
    
            public Bag()
            {
                BagConfig = new BagConfig();
            }
        }
    
        public class BagConfig
        {
            [XmlAttribute]
            public string Name { get; set; }
    
            [XmlAttribute]
            public int ZenDrop { get; set; }
    
            [XmlAttribute]
            public int ItemRate { get; set; }
    
            [XmlAttribute]
            public int ExcRate { get; set; }
    
            [XmlAttribute]
            public int AncientRate { get; set; }
    
            [XmlAttribute]
            public int SocketRate { get; set; }
        }
    
        public class Default
        {
            public DefaultConfig DefaultConfig { get; set; }
    
            public Default()
            {
                DefaultConfig = new DefaultConfig();
            }
        }
    
        public class DefaultConfig
        {
            [XmlAttribute("cat")]
            public int Category { get; set; }
    
            [XmlAttribute("id")]
            public int ID { get; set; }
    
            [XmlAttribute("minlv")]
            public int MinLevel { get; set; }
    
            [XmlAttribute("maxlv")]
            public int MaxLevel { get; set; }
    
            [XmlAttribute("skill")]
            public int Skill { get; set; }
    
            [XmlAttribute("luck")]
            public int Luck { get; set; }
    
            [XmlAttribute("addopt")]
            public int Addopt { get; set; }
    
            [XmlAttribute("exc")]
            public int Exc { get; set; }
    
            [XmlAttribute("anc")]
            public int Anc { get; set; }
    
            [XmlAttribute("sock")]
            public int Sock { get; set; }
        }
    
        public class Item
        {
            [XmlAttribute("cat")]
            public int Category { get; set; }
    
            [XmlAttribute("id")]
            public int ID { get; set; }
    
            [XmlAttribute("minlv")]
            public int MinLevel { get; set; }
    
            [XmlAttribute("maxlv")]
            public int MaxLevel { get; set; }
    
            [XmlAttribute("skill")]
            public int Skill { get; set; }
    
            [XmlAttribute("luck")]
            public int Luck { get; set; }
    
            [XmlAttribute("addopt")]
            public int Addopt { get; set; }
    
            [XmlAttribute("exc")]
            public int Exc { get; set; }
    
            [XmlAttribute("anc")]
            public int Anc { get; set; }
    
            [XmlAttribute("sock")]
            public int Sock { get; set; }
        }
