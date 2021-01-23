    static List<T> CreateList<T>(IEnumerable<T> stuff)
    {
    	return new List<T>(stuff);
    }
    
    static IEnumerable<T> SubSet<T>(IEnumerable<T> sequence, Predicate<T> predicate)
    {
    	foreach (var item in sequence)
    		if (predicate(item)) yield return item;
    }
    
    static void Main(string[] args)
    {
    	var list = CreateList(new[]
    			                {
    			                new {val = 1,
    			                    date = DateTime.Now,
    			                    id = Guid.NewGuid()},
    			                new {val = 2, 
    			                    date = DateTime.Now.AddDays(1),
    			                    id = Guid.NewGuid()}
    			                });
    
    	var subset = SubSet(list, item=>item.val == 1);
    }
