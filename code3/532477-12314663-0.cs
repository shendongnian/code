    public static class ContainerHolder
    {
       public static Container Container {get;set;}
    }
    public class Foo : IFoo
    {
      private IBar _bar;
    
      public Foo(IBar bar)
      {
        _bar = bar;
      }
    }
    
    public class Bar : IBar
    {
      private IFoo _foo
      {
        get { return ContainerHolder.Container.Resolve<IFoo>(); }
      }
    
      public Bar()
      {
      }
    
    }
