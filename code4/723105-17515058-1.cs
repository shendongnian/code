    public class OuterClass
    {
        private OuterClass() {  }
     
        public static OuterClass GetOuter() { return new OuterClass(); }   
    }
