    using System;
    using System.Collections.Generic;
    namespace HelloWorld
    {
    	public class Program
    	{
    		public static void Main ()
    		{
    			Dictionary<string, string> dict = new Dictionary<string, string> {
    				{ "a", "b" }
    			};
    
    			Dog dog;
    			if (dict.TryGet (out dog))
    			{
    				Console.WriteLine(dog.Color);
    			}
    		}
    	}
    	public static class ExtensionMethods
    	{
    		public static bool TryGet(this Dictionary<string, string> dictionary, out Dog dog)
    		{
    			dog = new Dog();
    			dog.Color = "black / white";
    			return true;
    		}
    	}
    
    	public class Dog
    	{
    		public string Color { get; set; }
    	}
    }
