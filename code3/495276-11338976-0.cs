    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public static List<Item> Data()
        {
            List<Item> list = new List<Item>()
            {
                    new Item(){ ID=11, Name="A"},
                    new Item(){ ID=12, Name="B"},
                    new Item(){ ID=13, Name="C"},
                    new Item(){ ID=14, Name="D"},
                    new Item(){ ID=15, Name="E"},
            };
            return list;
        }
    }
