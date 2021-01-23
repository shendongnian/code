    public class IntWrapper
    {
        public int Value { get; set; }
        public IntWrapper(int value) { Value = value; }
    }
    IntWrapper o1 = new IntWrapper(5);
    IntWrapper o2 = o1;
    
    o2.Value = 8; 
