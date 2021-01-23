    void Main()
    {
        var x = new Host { E = new B() };
	
        Console.Write(x.E.GetType().Equals(typeof(B)));
    }
    class A { }
    class B : A { }
    class Host { public A E { get; set; } }
