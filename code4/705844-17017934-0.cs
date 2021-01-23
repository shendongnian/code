    public class IntList : List<int>, IEquatable<IntList>
    {
    	public bool Equals(IntList other)
    	{
    		return this.SequenceEqual(other);
    	}
    }
    
    void Main()
    {
    	List<IntList> list1 = new List<IntList>(2);
    	List<IntList> list2 = new List<IntList>(2);
    	
    	var list11 = new IntList() {1, 2, 3};
    	list1.Add(list11);
    	
    	var list21 = new IntList() {1, 2, 3};
    	list2.Add(list21);
    	
    	
    	var result = list1.SequenceEqual(list2);
    	Console.WriteLine(result);
    }
