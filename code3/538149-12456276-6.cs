    interface IFoo
    {
        int Id { get;  }
    }
    
    class Foo : IFoo
    {
        public int Id { get; set; }  // protected/private set is OK too
    }
