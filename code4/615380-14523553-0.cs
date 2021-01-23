    class A
    {
        virtual string GetString()
        {
            return "Called from A";
        }
    }
    class B : A
    {
        override string GetString()
        {
            return "Called from B";
        }
    }
    static void Main(string[] args)
    {
        A b = new B();
        Print(b);
    }
    static void Print(A a)
    {
        Console.WriteLine(a.GetString());
    }
