    public void Test()
    {
        Node root = new Node();
        Node child = new Node();
        Data data = new Data() { Area = 276, Color = "#8E7032", PlayCount = "276", Image = "http://userserve-ak.last.fm/serve/300x300/11403219.jpg" };
        Node grandChild = new Node() { Id = "album-Thirteenth Step", Name = "Thirteenth Step", Data = data };
        root.Children.Add(child);
        child.Children.Add(grandChild);
           
        var json = JsonConvert.SerializeObject(
                                  root, 
                                  new JsonSerializerSettings() {  
                                      NullValueHandling= NullValueHandling.Ignore,
                                      Formatting= Newtonsoft.Json.Formatting.Indented
                                  });
    }
    public class Node
    {
        [JsonProperty("children")]
        public List<Node> Children = new List<Node>();
        [JsonProperty("data")]
        public Data Data;
            
        [JsonProperty("id")]
        public string Id;
            
        [JsonProperty("name")]
        public string Name;
    }
    public class Data
    {
        [JsonProperty("playcount")]
        public string PlayCount;
            
        [JsonProperty("$color")]
        public string Color;
            
        [JsonProperty("image")]
        public string Image;
            
        [JsonProperty("$area")]
        public int Area;
    }
