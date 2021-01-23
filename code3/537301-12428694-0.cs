    class Foo
    {
    	public Dictionary<int, int> RefStat {get;private set;}
    	
    	Foo()
    	{
    		RefStat = new Dictionary<int, int> 
    		{
    			{1,2},
    			{2,3},
    			{3,5} 
    		};
    	}
    }
