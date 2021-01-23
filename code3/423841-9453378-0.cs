    class Test
    {
        public int x;
        public int y;
        public Test()
        {
            x = 1;
        }
        public Test(int y) : this() // remove this() and x will stay 0
        {
            this.y = y;
        }
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Test(5);
            Console.WriteLine("x={0} y={1}", t.x, t.y);
        }
    }
