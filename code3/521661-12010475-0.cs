    var itemList = ((JObject)JsonConvert.DeserializeObject(json))["response"]
                    .Skip(1)
                    .Select(x => JsonConvert.DeserializeObject<Item>(x.ToString()))
                    .ToList();
    public class Item
    {
        public int mid { set; get; }
        public string date { set; get; }
        public int @out { set; get; }
        public int  uid { set; get; }
        public int read_state { set; get; }
        public string title { set; get; }
        public string body { set; get; }
    }
