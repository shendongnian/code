    public class MyClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    
        private Lazy<int> lazyGetSum = new Lazy<int>(new Func<int>(() => 2 + 3));
        public int Sum { get { return lazyGetSum.Value; } }
    
    }
