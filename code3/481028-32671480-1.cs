    using System;
    using System.Collections.Generic;
    
    
    public class Program
    {
    	public static void Main()
    	{
    		Bictionary<string, int> map = new Bictionary<string,int>() { { "a",1 }, { "b",2 }, { "c",3 } };
    		Console.WriteLine(map["b"]);
    		Console.WriteLine(map[3]);
    	}
    }
    
    public class Bictionary<T1, T2> : Dictionary<T1, T2>
    {
    	private Dictionary<T2, T1> _reverseDictionary = new Dictionary<T2, T1>();
    	
    	public T1 this[T2 index]
    	{
    		get
    		{
    			return _reverseDictionary[index];
    		}
    
    		set
    		{
    			_reverseDictionary[index] = value;
    		}
    	}
    	
    	public new void Add(T1 key, T2 value)
    	{
    		base.Add(key,value);
    		_reverseDictionary.Add(value,key);
    	}
    	
    }
