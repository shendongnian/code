    public class MyClass
    {
        public int X { get; set; }
        public int Y { get; set; }
        private readonly LazyValue<int> lazyGetSum = new LazyValue<int>();
        public int Sum { get { return lazyGetSum.GetValue(() => X + Y); } }
    }
