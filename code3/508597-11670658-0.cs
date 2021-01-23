    public class Item
    {
        public ProfileTypeEnum ProfileType { get; set; }
        public string ProfileName { get; set; }
        public int ProfileTypeValue { get { return (int)ProfileType; } }
    }
