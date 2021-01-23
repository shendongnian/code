    class Item
    {
    	public int Id {get; set;}
    	public string Name {get;set;}
    }
    
    class ItemComparer : IEqualityComparer<Item>
    {
    	public bool Equals(Item x, Item y)
    	{
    	    return x.Id == y.Id;
    	}
    	
    	public int GetHashCode(Item x)
    	{
    	    return x.Id;
    	}
    }
    
    void Main()
    {
      var sequence = new List<Item>() 
      {
          new Item {Id = 1, Name = "1"}, 
    	  new Item {Id = 1, Name = "2"}
      };
      
      // Using overloaded version of Distinct method!
      var distinctSequence = sequence.Distinct(new ItemComparer());
      
      // distinctSequence contains inly one Item with Id = 1
      distinctSequence.Dump();
    }
