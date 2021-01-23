    class B : A
    {
        public B()
        {
            Console.WriteLine("I AM DERIVED class");
        }
        public B(int x)
        : A(x)
        {
            Console.WriteLine("I AM DERIVED class (with a parameter)");
        }
    }
