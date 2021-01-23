    private class FooNode : TreeNode
    {
    	public FooNode(Foo foo)
    	{
    		this.Text = foo.ToString(); //Or FriendlyName
    		this.Foo = foo;
    		this.Foo.Bars.ForEach(x => this.Nodes.Add(new BarNode(x)));
    	}
    
    	public Foo Foo
    	{
    		get;
    		private set;
    	}
    }
    
    private class BarNode : TreeNode
    {
    	public BarNode(Bar bar)
    	{
    		this.Text = bar.ToString(); //Or FriendlyName
    		this.Bar = bar;
    	}
    
    	public Bar Bar
    	{
    		get;
    		private set;
    	}
    }
