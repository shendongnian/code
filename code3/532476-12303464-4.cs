    // interfaces
    public interface IBar
    {
        IFoo Foo { get; set; }
    }
    
    public interface IFoo
    {
        IBar Bar { get; set; }
    }
    
    // implementations
    public class Foo : IFoo
    {
        public IBar Bar { get; set; }
    }    
    
    public class Bar : IBar
    {
        public IFoo Foo { get; set; }
    }
    
    // usage
    container.Register<IBar>(c => new Bar());
    container.Register<IFoo>(c => 
    {
        var bar = c.Resolve<IBar>();
        var foo = new Foo();
        
        bar.Foo = foo;
        foo.Bar = bar;
    });
