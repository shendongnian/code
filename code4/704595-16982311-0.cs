    [FixedLengthRecord()] 
    public class MyFileHelpersClass
    {
        [FieldFixedLength(5)] 
        public String Cstrid;
        [FieldFixedLength(10)] 
        public String Name;
        [FieldFixedLength(10)] 
        public String Phn1;
        [FieldFixedLength(20)] 
        public String Email1;
        [FieldFixedLength(10)] 
        public String Phn2;
        [FieldFixedLength(20)] 
        public String Email2;
        // etc.
    }      
