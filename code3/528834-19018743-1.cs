    public class DataContractSystemJsonSerializer : XmlObjectSerializer
    {
        protected DataContractJsonSerializer innerSerializer;
    
    
        public DataContractSystemJsonSerializer(Type t)
        {
            this.innerSerializer = new DataContractJsonSerializer (t);
        }
        ...
    
    }
