    class Program
    {
    	static void Main(string[] args)
    	{
    		var client = new Service1Client();
    
    		for (int i = 0; i < 10000; i++)
    		{
    			string response = client.GetData(42);
    			Console.WriteLine("Response: '" + response + "'");
    		 
    		}
    		Console.ReadLine();
    	}
    }
