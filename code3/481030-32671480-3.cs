    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		Bictionary<string, int> bictionary = 
    			new Bictionary<string,int>() {
    				{ "a",1 }, 
    				{ "b",2 }, 
    				{ "c",3 } 
    			};
    		
    		// test forward lookup
    		Console.WriteLine(bictionary["b"]);
    		// test forward lookup error
    		//Console.WriteLine(bictionary["d"]);
    		// test reverse lookup
    		Console.WriteLine(bictionary[3]); 
    		// test reverse lookup error (throws same error as forward lookup does)
    		Console.WriteLine(bictionary[4]); 
    	}
    }
    
    public class Bictionary<T1, T2> : Dictionary<T1, T2>
    {
    	public T1 this[T2 index]
    	{
    		get
    		{
    			if(!this.Any(x => x.Value.Equals(index)))
    			   throw new System.Collections.Generic.KeyNotFoundException();
    			return this.First(x => x.Value.Equals(index)).Key;
    		}
    	}
    }
