    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace brosell
    {
    
    public class MyBase
    {
    
    }
    
    public class ItemChange
    {
        public DateTime When { get; set; }
    
    }
    
    public class ItemChange<T>: ItemChange where T : MyBase
    {
        public string Who { get; set; }
        public T NewState;
        public T OldState;
    }
    
    public class Sub1: MyBase
    {
    
    }
    
    public class Sub2: MyBase
    {
    
    }
    
       public class HelloWorld
       {
       	public static void Main(string[] args)
       	{
    		List<ItemChange<Sub1>> listOfSub1 = new List<ItemChange<Sub1>>();
    		List<ItemChange<Sub2>> listOfSub2 = new List<ItemChange<Sub2>>();
    		
    		var concated = listOfSub1.Cast<ItemChange>().Concat(listOfSub2.Cast<ItemChange>());
    	
    		var filtered = concated.OrderByDescending(ic => ic.When).Take(10);	
    		
    		Console.WriteLine("{0}", filtered.Count());
          	}
       } 
    }
       
