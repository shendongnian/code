    class Foo
    {
        public int Id { get; set; }
    }
    
    class Bar
    {
        public Bar(Foo parent)
        {
        }
    
        public Bar()
            : this(new Foo { Id = 1 }) // this can't be done with default parameters
        {
        }
    }
