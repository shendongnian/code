    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		Bictionary<string, int> bictionary = new Bictionary<string,int>() { { "a",1 }, { "b",2 }, { "c",3 } };
    		Console.WriteLine(bictionary["b"]);
    		//Console.WriteLine(bictionary["d"]);
    		Console.WriteLine(bictionary[3]);
    		Console.WriteLine(bictionary[4]); // throws same error as forward lookup does
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
