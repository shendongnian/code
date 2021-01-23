    class A
    {
        public new string ToString()
        {
            return "bugaga!";
        }
    }
    static void Main(string[] args)
    {
        var a = new A();
        Console.WriteLine(a.ToString());
        Console.WriteLine(a); // here a will casted to object
    }
