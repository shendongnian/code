    interface IFoo
    {
        int Id { get;  }
    }
    
    class Foo : IFoo
    {
        public int Id { get; protected set; }  // public set is OK too
    }
