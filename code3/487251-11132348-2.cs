    var list = JsonConvert.DeserializeObject<List<MyItem>>(json);
    public class MyItem
    {
        public string id;
        public string displayName;
        public string name;
        public string slug;
        public string imageUrl;
    }
