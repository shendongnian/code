    public class pair
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
    
        public pair(string key, string value)
        {
            this.Key= key;
            this.Value = value;
        }   
    }
