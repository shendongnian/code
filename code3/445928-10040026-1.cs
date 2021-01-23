    class Number
    {
        public static Number test;
        private int x;
        public Number(int x) { this.x = x; }
        public Number AddOne() 
        {
            return new Number(x + 1);
        }
        public void DoIt()
        {
            Console.WriteLine(x);
            test = test.AddOne();
            Console.WriteLine(x);
        }
        public static void Main()
        {
            test = new Number(1);
            test.DoIt(); 
        }
    }
