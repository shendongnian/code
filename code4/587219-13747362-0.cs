    public interface IAsset
    {
        string Bling { get; set; }
    }
    public class AAsset : IAsset
    {
        public string Bling { get; set; }
        public override string ToString()
        {
            return "A" + Bling;
        }
    }
    public class BAsset : IAsset
    {
        public string Bling { get; set; }
        public override string ToString()
        {
            return "B" + Bling;
        }
    }
    public class AssetBag
    {
        [JsonProperty(TypeNameHandling = TypeNameHandling.None)]
        public List<IAsset> Assets { get; set; } 
    }
    class Program
    {
        
        
        static void Main(string[] args)
        {
            try
            {
                var bag = new AssetBag
                    {
                        Assets = new List<IAsset> {new AAsset {Bling = "Oho"}, new BAsset() {Bling = "Aha"}}
                    };
                string json = JsonConvert.SerializeObject(bag, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                var anotherBag = JsonConvert.DeserializeObject<AssetBag>(json, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
