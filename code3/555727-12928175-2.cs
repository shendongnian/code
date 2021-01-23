    public class Pair
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
    
        public Pair(string key, string value)
        {
            this.Key= key;
            this.Value = value;
        }   
    }
