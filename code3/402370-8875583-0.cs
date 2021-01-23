      public interface IFoo
        {
            Int32 Id { get; }
        }
       public interface IFooMu : IFoo
        {
            new Int32 Id { get; set; }
        }  
        class Foo : IFooMu
        {
            public Int32 Id { get; set; }
        }
