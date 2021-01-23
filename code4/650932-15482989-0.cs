    internal static class Program
    {
    	private static void Main()
    	{
    		var deriver = new Rfc2898DeriveBytes("apples and oranges", 100, 20);
    		Program.WriteArray(deriver, 5);
    		Program.WriteArray(deriver, 10);
    		Program.WriteArray(deriver, 20);
    
    		Console.ReadLine();
    	}
    
    	private static void WriteArray(Rfc2898DeriveBytes source, int count)
    	{
    		source.Reset();
    		Console.WriteLine(string.Join(" ", source.GetBytes(count).Select(b => b.ToString())));
    	}
    }
