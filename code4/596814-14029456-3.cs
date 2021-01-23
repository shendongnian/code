    public class MyClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    
        private Lazy<int> lazyGetSum;
        public MyClass()
        {
            lazyGetSum = new Lazy<int>(() => X + Y);
        }
        public int Sum{ get { return lazyGetSum.Value; } }
    }
