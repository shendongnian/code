    public class MyClass
    {
        public int FirstValue { get; set; }
        public int SecondValue {get; set; }
    
        public int[] IDs
        {
            return new[] { FirstValue, SecondValue };
        }
    }
