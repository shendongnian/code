    class Some
    {
        string Property { get; set; }
    }
    class Foo
    {
        public List<Some> Objects { get; set; }
    }
    
    foo.Objects[0].Property
