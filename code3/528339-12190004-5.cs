    private List<Int32> _Foo = new List<Int32>() { 1, 2, 3, 4, 5 };
    
    public IEnumerable<Int32> Foo
    {
    	get
    	{
    		foreach (var item in _Foo)
    		{
    			var result = DoSomethingExpensive(item);
    			yield return result;
    		}
    	}
    }
