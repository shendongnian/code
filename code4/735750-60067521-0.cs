    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(strGen("01",3));
    	}
    	//param s is the string that you can generete and the n param is the how many times.
    	private static string strGen(String s, int n){
    		string r = string.Empty;
            for (int x = 1; x <= n; x++)
                r += string.Copy(s);
            return r;
    	}
    }
