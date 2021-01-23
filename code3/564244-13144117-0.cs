    void Main()
    {
    	//Your provided sample data
    	IEnumerable<Item> data = new Item[]
    	{
    		new Item{ A = 1, B = 2, C = 3, D = 4 },
    		new Item{ A = 1, B = 2, C = 9, D = 4 },
    	};
    	
    	//Create a custom comparer for distinct'ing
    	CustomComparer comparer = new CustomComparer();
    	
    	//Use the overload for distinct
    	IEnumerable<Item> distinctData = data.Distinct(comparer);
    	
    	//Now we have a distinct list according to your comparer
    	foreach (var element in distinctData)
    	{
    		Console.WriteLine(element.C.ToString()); // => 3
    	}
    }
    
    //sample class that holds your data
    class Item
    {
    	public int A  { get; set; }
    	public int B  { get; set; }
    	public int C  { get; set; }
    	public int D  { get; set; }
    }
    
    class CustomComparer : IEqualityComparer<Item>
    {
       public bool Equals(Item x, Item y)
       {
           return x.D == y.D;
       }
    
       public int GetHashCode(Item obj)
       {
           return obj.D;
       }
    }
