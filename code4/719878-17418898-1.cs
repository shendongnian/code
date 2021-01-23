    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    
        [NotMapped]
        public Version Version { get; set; }
    
        [Column("Version")]
        public string VersionValue
        {
            get { return Version != null ? Version.ToString() : null; }
            set { Version = Version.Parse(string); }
        }
    }
