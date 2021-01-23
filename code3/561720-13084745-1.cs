    void Main()
    {
    	var matches = new List<List<ComparissonItem>> { /*Your Items*/ };
    	
    	var overall =
    		from match in matches
    		let matchesOne =
    			(from searchItem in matches
    			 where searchItem.Any(item => match.Any(val => val.Matches(item) && !val.Equals(item)))
    			 select searchItem)
    		where matchesOne.Any()
    		select
    			matchesOne.Union(new List<List<ComparissonItem>> { match })
    			.SelectMany(item => item);
    			
        var result = overall.Select(item => item.ToHashSet());
    }
    
    static class Extensions
    {
    
    	public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
    	{
    		return new HashSet<T>(enumerable);
    	}
    }
    
    class ComparissonItem
    {
    	public int Value { get; set; }
    
    	public bool Matches(ComparissonItem item)
    	{
    	    /* Your matching logic*/
    	}
    
    	public override bool Equals(object obj)
    	{
    		var other = obj as ComparissonItem;
    		return other == null ? false : this.Value == other.Value;
    	}
    	
    	public override int GetHashCode()
    	{
    		return this.Value.GetHashCode();
    	}
    }
