    public class Foo
    {
    }
    public class Bar
    {
    }
    // adapter takes Foo and pretends it is Bar
    public class FooBarAdapter : Bar
    {
       public FooBarAdapter( Foo foo )
       {
       }
    }
    // decorator maintains the interface and adds features
    public class FooDecorator : Foo
    {
        public FooDecorator( Foo foo )
        {
        }
    }
