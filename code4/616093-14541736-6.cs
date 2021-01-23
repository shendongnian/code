    class Int32Adder : IAdder<Int32>
    {
        public static readonly Instance = new Int32Adder();
        public int Zero { get { return 0; } }
        public int Add(int a, int b) { return a + b; }
    }
