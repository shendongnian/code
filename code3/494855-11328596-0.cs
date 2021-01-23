    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public static List<List<Item>> getItems()
        {
            List<Item> list = new List<Item>()
            {
                    new Item(){ ID=11, Name="A"},
                    new Item(){ ID=12, Name="B"},
                    new Item(){ ID=13, Name="C"},
                    new Item(){ ID=14, Name="D"},
                    new Item(){ ID=15, Name="E"},
            };
    
            /* Split the list as per specified size */
    
            int size = 2;
            var lists = Enumerable.Range(0, (list.Count + size - 1) / size)
                        .Select(index => list.GetRange(index * size,
                            Math.Min(size, list.Count - index * size)))
                        .ToList();
    
            return lists;
        }
    }
