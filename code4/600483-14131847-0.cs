    using System;
    class MainClass
    {
    	public static void Main (string[] args)
    	{
    		float[,] b = new float[4,4];
    		Test(b);
    		Console.WriteLine ("Hello World!");
    	}
    
    	static void Test(float[,] x)
    	{
    		float[,] y = x;
    	}
    }
