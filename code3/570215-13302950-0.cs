    void Main()
    {
    	List<DataObject> set1 = new List<DataObject>();
    	List<DataObject> set2 = new List<DataObject>();
    	
    	set1.Add(new DataObject("a"));
    	set1.Add(new DataObject("b"));
    	set1.Add(new DataObject("c"));
    	set1.Add(new DataObject("d"));
    	set1.Add(new DataObject("e"));
    	
    	set2.Add(new DataObject("c"));
    	set2.Add(new DataObject("d"));
    	set2.Add(new DataObject("e"));
    	set2.Add(new DataObject("f"));
    	set2.Add(new DataObject("g"));
    	set2.Add(new DataObject("h"));
    	
    	// try as  
    	// foreach (DataObject d in set1.Union(set2)) {
    	// and dupes will be present
    	
    	foreach (DataObject d in set1.Union(set2, new DOComparer())) {
    		Console.WriteLine(d);
    	}
    }
    
    // Define other methods and classes here
    public class DataObject {
    	public DataObject(string value) {
    		Value = value;
    	}
    	public string Value {get;private set;}
    	
    	public override string ToString() {
    		return Value;
    	}
    }
    
    public class DOComparer:IEqualityComparer<DataObject> {
    	public bool Equals(DataObject do1, DataObject do2) {
    		return do1.Value.Equals(do2.Value);
    	}
    	
    	public int GetHashCode(DataObject d) {
    		return d.Value.GetHashCode();
    	}
    }
