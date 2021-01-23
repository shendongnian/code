    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace brosell
    {
    
    public class MyBase
    {
    
    }
    
    
    
    public class ItemChange<T> where T : MyBase
    {
    	public DateTime When { get; set; }
        public string Who { get; set; }
        public T NewState;
        public T OldState;
        
        public static explicit operator ItemChange<MyBase>(ItemChange<T> i)
       {
          return new ItemChange<MyBase> { When = i.When, Who = i.Who, NewState = i.NewState, OldState = i.OldState};
       }
    
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
       		ItemChange<Sub1> item = new ItemChange<Sub1>();
       		
       		
       		ItemChange<MyBase> itemCasted = (ItemChange<MyBase>)item;
          	}
       } 
    }
   
 
