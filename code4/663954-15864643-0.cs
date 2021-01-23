    class Item<T>
    {
        public String Name { get; set; }
        public DataValueType DataType { get; set; }
        public T DataValue { get; set; }
    }
    class ItemRepository
    {
        private Dictionary<string, object> ItemList = new Dictionary<string, object>();
        public void Add<T>(Item<T> item) { ItemList[item.Name] = item; }
        public T GetItemValue<T>(string key)
        {
            var item = ItemList[key] as Item<T>;
            return item != null ? item.DataValue : default(T);
        }
    }
