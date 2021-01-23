    public class Items
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public List<Version> Versions { get; set; }
    }
    
    public class Version
    {
        public string Appid { get; set; }
        public string Version { get; set; }
        public string Patch_Notes { get; set; }
        public string Download_Link { get; set; }
        public int Size { get; set; }
    }
