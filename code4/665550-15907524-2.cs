    public class PropertyDictionary
    {
        Dictionary <string, StringProperty> dictionary;
        public PropertyDictionary()
        {
            dictionary = new Dictionary <string, ItemProperties>();
        }
        
        // Indexer; returns RenderedProp instead of Value
        public string this[string key]
        {
            return dictionary[key].RenderedProp;
        }
    }
    
