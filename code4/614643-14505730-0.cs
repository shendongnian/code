    using System;
    class Base
    {
    	public static void M() {
    		Console.WriteLine("Base.M");
    	}
    }
    class Derived: Base 
    {
    	new public class M 
    	{
    		public static void F() {
    			Console.WriteLine("Derived.M.F");
    		}
    	}
    }
    class Test 
    {
    	static void Main() {
    		Derived.M.F();
    	}
    }
