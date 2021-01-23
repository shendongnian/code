    var plugin = JsonConvert.DeserializeObject<Plugin>(json);
    public class Plugin
    {
        public List<string> authors;
        public string bukkitdev_link;
        public List<string> categories;
        public string desc;
        public string name;
        public string plugin_name;
        public string status;
    }
