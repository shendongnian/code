    class CustomJavaScriptSerializer : JavaScriptSerializer
    {
        public Dictionary<string, string> TheJsonDictionary { get; private set; }
    
        public string Serialize(object obj, Dictionary<string, string> TheJsonDictionary = null)
        {
            this.TheJsonDictionary = TheJsonDictionary;
            return base.Serialize(obj);
        }
    }
