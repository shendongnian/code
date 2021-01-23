    imac:~ sklivvz$ cat mod.cs 
    using System;
    
    public class Program
    {
    	public static void Main (string[] args)
    	{
    		Console.WriteLine(Mod(-2, 5));
    		Console.WriteLine(Mod(-5, 5));
    		Console.WriteLine(Mod(-2, -5));    
    	}
    	
    	public static int Mod (int n, int m)
    	{
    		return ((n % m) + m) % m;
    	}
    }
    imac:~ sklivvz$ mono mod.exe
    3
    0
    -2
    imac:~ sklivvz$ cat mod.py
    print -2%5;
    print -5%5;
    print -2%-5;
    imac:~ sklivvz$ python mod.py 
    3
    0
    -2
