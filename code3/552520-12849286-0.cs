    public class KeyWordWrapper
    {
        public string Url { get; private set; }
        public string Value { get; set; }
        
        public KeyWordWrapper(string url)
        {
            this.Url = url;
        }
        public override string ToString()
        {
            return string.Format("Url: {0} --- Localy KeyWord: {1}", Url, Value);
        }
    }
