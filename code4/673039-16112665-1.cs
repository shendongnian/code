    public class EnhancedFooBox : IEnhancedFooBox
    {
        public IEnhancedFoo Foo { get; set; }
        IFoo IFooBox.Foo { get; set; }
    }
    public class FooBase : IFoo
    {
        public string Name { get; set; }
    }
    public class EnhancedFoo : IEnhancedFoo
    {
        public int BarCount { get; set; }
        public string Name { get; set; }
    }
