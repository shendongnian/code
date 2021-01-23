    WebClient wc = new WebClient();
    string json = wc.DownloadString("http://api.bukget.org/api2/bukkit/category/Teleportation");
    var items = JsonConvert.DeserializeObject<List<MyItem>>(json);
    public class MyItem
    {
        public string description;
        public string name;
        public string plugname;
    }
