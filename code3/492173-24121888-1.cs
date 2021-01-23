        public class DisplayBindItem
        {
            private string key = string.Empty;
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string value = string.Empty;
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public DisplayBindItem(string k, string val)
        {
            this.key = k;
            this.value = val;
        }
        public DisplayBindItem()
        { }
    }
