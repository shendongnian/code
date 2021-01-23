    void Main()
    {
    	var allNodes = GetTreeNodes().Flatten(x => x.Elements);
    	
    	allNodes.Dump();
    }
    
    public static class ExtensionMethods
    {
    	public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector = null)
    	{
    		if (source == null)
    		{
    			return new List<T>();
    		}
    
    		var list = source;
    
    		if (childrenSelector != null)
    		{
    			foreach (var item in source)
    			{
    				list = list.Concat(childrenSelector(item).Flatten(childrenSelector));
    			}
    		}
    
    		return list;
    	}
    }
    
    IEnumerable<MyNode> GetTreeNodes() {
    	return new[] { 
    		new MyNode { Elements = new[] { new MyNode() }},
    		new MyNode { Elements = new[] { new MyNode(), new MyNode(), new MyNode() }}
    	};
    }
    
    class MyNode
    {
     	public MyNode Parent;
     	public IEnumerable<MyNode> Elements;
     	int group = 1;
    }
