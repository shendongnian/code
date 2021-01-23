    var plugin = JsonConvert.DeserializeObject<Plugin>(json);
    string categories = String.Join(",",plugin.categories);
    public class Plugin
    {
        public List<string> authors;
        public string bukkitdev_link;
        public List<string> categories;
        public string desc;
        public string name;
        public string plugin_name;
        public string status;
        public List<Version> versions;
    }
    public class Version
    {
        public string date;
        public string filename;
        public string name;
        //.......
    }
