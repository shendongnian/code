    public class pair
    {
    
        private string key;
        private string value;
    
        public pair(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    
        private string Key 
        {
            get { return key; }
            set { key = value; }
        }
    
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
