    void Main()
    {
    	var ints = new []{new []{1,2},new []{3,4},new []{2,4},new []{9,10},new []{9,12}};
    	var grouped = ints.Aggregate(new List<HashSet<int>>(), Step);
    	
    	foreach(var bucket in grouped)
    		Console.WriteLine(String.Join(",", bucket.OrderBy(b => b)));
    }
    
    static List<HashSet<T>> Step<T>(List<HashSet<T>> all, IEnumerable<T> current)
    {
    	var bucket = new HashSet<T>();
    	
    	foreach (var c in current)
    		bucket.Add(c);
    	
    	foreach (var i in all.Where(b => b.Intersect(bucket).Any()).ToArray())
    	{
    		foreach (var c in i)
    			bucket.Add(c);
    		all.Remove(i);
    	}
    	all.Add(bucket);
    	
    	return all;	
    }
