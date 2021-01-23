    static void Main()
    {
    	var list = new List<MutableStruct>()
    	{
    		new MutableStruct { Value = 10 }
    	};
    
    	foreach (MutableStruct item in list)
    	{
    	   var c = new Closure(item);
    		
           Console.WriteLine(c.Item.Value);
           Console.WriteLine("Before: {0}", c.Item.Value);  // 10
           c.Item.AssignValue(30);
           Console.WriteLine("After: {0}", c.Item.Value);   // Still 10!
    	}
    }
    
    class Closure
    {
    	public Closure(MutableStruct item){
    	Item = item;
    }
        //readonly modifier is mandatory
    	public readonly MutableStruct Item;
    	public void Foo()
    	{
    		Console.WriteLine(Item.Value);
    	}
    }  
