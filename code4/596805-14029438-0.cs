    public  class MyClass
        {
            public static int X { get; set; }
            public static int Y { get; set; }
    
            private Lazy<int> lazyGetSum = new Lazy<int>(new Func<int>(() => X + Y));
            public int Sum { get { return lazyGetSum.Value; } }
        }
