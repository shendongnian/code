    void Main()
    {
    	var list = new MyList() { new Stuff() { ugg = "z" }, new Stuff() { ugg = "b" } };
    	
    	var myOrderedList = list.OrderBy(s => s.ugg);
    	
    	myOrderedList.ToList().Dump();
    	
    	var list2 = new MyList();
    	list2.AddRange(myOrderedList);
    	list2.GetType().Name.Dump();
    }
    
    public class Stuff{
    	public string ugg {get;set;}
    }
    // Define other methods and classes here
    public class MyList : List<Stuff>{
    }
