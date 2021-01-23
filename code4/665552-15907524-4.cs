    public class PropertyDictionary
    {
        Dictionary <string, StringProperty> dictionary;
        public PropertyDictionary()
        {
            dictionary = new Dictionary <string, StringProperty>();
        }
        
        // Indexer; returns RenderedProp instead of Value
        public string this[string key]
        {
            get { return dictionary[key].RenderedProp; }
            set { dictionary[key].RenderedProp = value; }
        }
    }
    
