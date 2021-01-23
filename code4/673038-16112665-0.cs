    public interface IFoo
    {
        string Name { get; set; }
    }
    public interface IEnhancedFoo : IFoo
    {
        int BarCount { get; set; }
    }
    public interface IFooBox
    {
        IFoo Foo { get; set; }
    }
    public interface IEnhancedFooBox : IFooBox
    {
        new IEnhancedFoo Foo { get; set; }
    }
