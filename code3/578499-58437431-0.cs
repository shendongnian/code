    interface Inter
    {
        void Call();
    }
    class A : Inter
    {
        //Explicitly implemented interface
        void Inter.Call()
        {
            this.Call();
        }
        public virtual void Call() { Console.WriteLine("Base call in A"); }
    }
    class B : A
    {
        public override void Call()
        {
            Console.WriteLine( "Called B" );
        }
    }
    class Program
    {
        static void Main( string[] args )
        {
            var a = new A();   //Base class
            var aa = (Inter)a; //Interface only
            a.Call();
            aa.Call();
            var b = new B();   //Child class
            var bb = (Inter)b; //Interface only of Child class
            b.Call();
            bb.Call();
            //See the output before the console program closes
            Console.ReadLine();         
        }
    }
