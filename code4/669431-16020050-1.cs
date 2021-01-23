    public void TestMethod1()
        {
            var items = new List<Item>
                            {
                                new Item { Att1 = "ABC", Att2 = "123" }, 
                                new Item { Att1 = "EFG", Att2 = "456" }, 
                                new Item { Att1 = "HIJ", Att2 = "789" }
                            };
            var root = new Root() { Items = items };
            var itemsSerialized = JsonConvert.SerializeObject(items);
            var rootSerialized = JsonConvert.SerializeObject(root);
            
            //This works
            var deserializedItemsFromItems = JsonConvert.DeserializeObject<List<Item>>(itemsSerialized); 
            
            //This works
            var deserializedRootFromRoot = JsonConvert.DeserializeObject<Root>(rootSerialized); 
            //This will fail.  YOu serialized it as root and tried to deserialize as List<Item>
            var deserializedItemsFromRoot = JsonConvert.DeserializeObject<List<Item>>(rootSerialized);
             
            //This will fail also for the same reason 
            var deserializedRootFromItems = JsonConvert.DeserializeObject<Root>(itemsSerialized);
        }
    class Root
    {
        public IEnumerable<Item> Items { get; set; } 
    }
    class Item
    {
        public string Att1 { get; set; }
        public string Att2 { get; set; }
    }
