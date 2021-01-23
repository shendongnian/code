    [Serializable()]		
    public class SimpleObject  {
    
        //A field that is serialized.
        public int member1;
       
        // A field that is not serialized.
        [NonSerialized()] public string member5; 
    
        public SimpleObject() {
    
            member1 = 11;
            member5 = "hello world!";
        }
     
    }
