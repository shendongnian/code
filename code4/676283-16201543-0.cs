    class A
    {
        public string name;
        public int year;
        public Object ToObject()
        {
            return new Object[] {name, year};
        }
    }
        List<A> foo = new List<A>
        {
            new A{name="reacher",year=2013},
            new A{name="Ray",year=2013}
        }; 
        var bux = foo.Select(a => a.ToObject()).ToArray() ;
