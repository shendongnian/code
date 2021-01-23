    public class PropertyDictionary
    {
        Dictionary <string, ItemProperties> dictionary;
        public PropertyDictionary()
        {
            dictionary = new Dictionary <string, ItemProperties>();
        }
        
        // Indexer; returns RenderedProp instead of Value
        public RenderedProp this[string key]
        {
            return dictionary[key].RenderedProp;
        }
    }
    
