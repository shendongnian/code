    public class EnumKeyAttribute : Attribute
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public EnumKeyAttribute(string key, string description)
        {
            this.Key = key;
            this.Description = description;
        }
    }
