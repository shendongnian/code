    class Foo
    {
    	public int Id { get; set; }
    	public int BarId { get; set; }
    	public virtual Bar Bar { get; set; }
    }
    
    class Bar
    {
    	public int Id { get; set; }
    	public int FooId { get; set; }
    	public virtual Foo Foo { get; set; }
    }
