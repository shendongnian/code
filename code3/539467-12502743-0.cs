    void Main() {
    	// Ascending by some other property
    	CreateOrdering(item => item.SomeProperty, SortDirection.Ascending).Dump("Ascending order for SomeClass.SomeProperty");
    	// Descending by some other property
    	CreateOrdering(item => item.SomeProperty, SortDirection.Descending).Dump("Descending order for SomeClass.SomeProperty");
    	// Ascending by the Code property
    	CreateOrdering(item => item.Code, SortDirection.Ascending).Dump("Ascending order for SomeClass.Code");
    	// Descending by the Code property
    	CreateOrdering(item => item.Code, SortDirection.Descending).Dump("Descending order for SomeClass.Code");
    }
    
    // I reccomend not using bare strings, and instead use an enum
    public enum SortDirection {
    	 Ascending = 0,
    	 Descending = 1
    }
    // Define other methods and classes here
    public List<SomeClass> CreateOrdering<T>(Expression<Func<SomeClass, T>> field, SortDirection direction) {
    	// query does not get executed yet, because we have not enumerated it.
    	var query = context.MyTable
    		.Where(x => x.Code > 5);
    		
    	if (direction.Equals(SortDirection.Ascending)) {
    		query = query.OrderBy (field);
    	} else {
    		query = query.OrderByDescending (field);
    	}
    	
    	// query gets executed when the call ToList is made.
    	return query.Skip(10)
    				.Take(5)
    				.ToList();
    }
    
    public static class context {
    	private static List<SomeClass> _MyTable = new List<SomeClass>() {
    		new SomeClass("A", 4), new SomeClass("B", 5), new SomeClass("C", 6),
    		new SomeClass("D", 7), new SomeClass("E", 8), new SomeClass("F", 9),
    		new SomeClass("G", 10), new SomeClass("H", 11), new SomeClass("I", 12),
    		new SomeClass("J", 13), new SomeClass("K", 14), new SomeClass("L", 15),
    		new SomeClass("M", 16), new SomeClass("N", 17), new SomeClass("O", 18)
    	};
    	
    	public static IQueryable<SomeClass> MyTable {
    		get {
    			return _MyTable.AsQueryable();
    		}
    	}
    }
    
    public class SomeClass {
    	public SomeClass(string property, int code) {
    		this.SomeProperty = property;
    		this.Code = code;
    	}
    	
    	public string SomeProperty { get; set; }
    	
    	public int Code { get; set; }
    }
