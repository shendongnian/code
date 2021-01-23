    public class MyClass
    {
        public int X { get; set; }
        public int Y { get; set; }
        private Lazy<int> lazyGetSum; 
        public int Sum { get { return lazyGetSum.Value; } }
        public MyClass()
        {
            lazyGetSum = new Lazy<int>(new Func<int>(() => X + Y));
        }
    }
