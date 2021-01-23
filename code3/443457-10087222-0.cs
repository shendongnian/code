    public delegate void OnDeserializedEventArgs(object itemDeserialized, string xmlSource);
    public delegate void OnDeserializedFailedEventArgs(string xmlSource);
    public static class SerializationServices
    {
        public static event OnDeserializedEventArgs OnDeserializedEvent;
        public static event OnDeserializedFailedEventArgs OnDeserializedFailedEvent;
        
        public static T Deserialize<T>(this string item) where T : class
        {
            XmlSerializer ser = new XmlSerializer(item.GetType());
            StringReader sr = new StringReader(item);
            var obj = ser.Deserialize(sr);
            
            if (obj is T)
            {
                if (OnDeserializedEvent != null)
                    OnDeserializedEvent(obj, item);
                return obj as T;
            }
            if (OnDeserializedFailedEvent != null)
                OnDeserializedFailedEvent(item);
            //callback - invalid event
            return null;
        }
    }
