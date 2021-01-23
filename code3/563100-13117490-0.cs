    class A
    {
        public B bRef;
        public C cRef;
    }
    class B
    {
        public int aBInt;
    }
    class C
    {
        public int aCInt;
    }
    class Program
    {
        static void Main(string[] args) 
        {
            A aRef = new A
                {
                    bRef = new B
                        {
                            aBInt = 10,
                        },
                    cRef = new C
                        {
                            aCInt = 10,
                        }
                };
        }
    }
