      class program
    {
       public int x = 10;
        public void fun1()
        {
            Console.WriteLine("as you wish");
        }
    }
    class program2:program
    {
        public void fun2()
        {
            Console.WriteLine("no");
            
            this.fun2(); //base class function call
            this.fun1(); // same class function call
        }
    }
    class program3:program2
    {
       public int x = 20;
        public void fun3()
        {
            Console.WriteLine(this.x); //same class x variable call
            Console.WriteLine(base.x); // base class x variable call
           // this.fun3(); // same class function call
            Console.WriteLine("Program3 class call");
            base.fun1(); //base class function call
        }
        static void Main(string[] args)
        {
            program3 pr = new program3();
            pr.fun3();
        }
