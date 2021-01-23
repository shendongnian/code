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
            var deserializedItemsFromItems = JsonConvert.DeserializeObject<List<Item>>(itemsSerialized); //This should work
            var deserializedRootFromRoot = JsonConvert.DeserializeObject<Root>(rootSerialized); //This should work
            var deserializedItemsFromRoot = JsonConvert.DeserializeObject<List<Item>>(rootSerialized); //This will fail.  YOu serialized it as root and tried to deserialize as List<Items>
            var deserializedRootFromItems = JsonConvert.DeserializeObject<Root>(itemsSerialized); //This will fail
