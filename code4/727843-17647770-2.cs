    public class Program
    {
    	public static void Main()
    	{
    		new Program();
    	}
    
    	public Program()
    	{
    		var server = new Server();
    		server.Listen();
    
    		var client = new Client();
    
    		var input = String.Empty;
    
    		while (input != "/quit")
    		{
    			input = Console.ReadLine();
    			Console.WriteLine(client.ReverseString(input));
    		}
    	}
    
    }
