    [DataContract()]
    [KnownType(typeof(stateCom))]
    [KnownType(typeof(stateIp))]
    abstract public  class  state
    {
        [DataMember()]
        public string tag;
        [DataMember()]
        public byte Id;
    
        public HandleConnection master;
    
    
        // default data contstructor for xml serialization
        public state()
        {
        }
    
        public abstract void openPort();
    
    
        public abstract void closePort();
    
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // this is called after deserialization
        }
    }
