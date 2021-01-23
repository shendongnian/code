    using System;
    public class Test
    {
    	public static void Main()
    	{
    		string test = @"T
    e
    s
    t";
    		for (int i =0 ; i < test.Length; i++)
    		{
    			Console.WriteLine("{0} == \\n? {1}", test[i], test[i] == '\n');
    		}
    	}
    }
