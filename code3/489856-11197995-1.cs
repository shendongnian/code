    public class Foo
    {
    	public string Prop1 { get; set; }
    	public Bar Prop2 { get; set; }
    }
    
    public class Bar
    {
    	public string BarProp { get; set; }
    	public Foo NestedFoo { get; set; }
    }
