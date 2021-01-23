    struct S 
    {
        public int j;
    }
    class D 
    {
        public S t;
    }
    ...
    D d = new D();
    Console.WriteLine(d.t.j);
