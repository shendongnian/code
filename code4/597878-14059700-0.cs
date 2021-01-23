    [DataContract]
    public class Tool
    {
        public Tool()
        {
            lastUse = 1;
            running = false;
        }
        
        public Func<int> action;
		
        [DataMember]
        public bool running;
		
        [DataMember]
        public int lastUse;
    }
