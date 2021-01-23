    using System.ServiceModel.ServiceHost;
    public class Sample
    {
    	ServiceHost host = new ServiceHost(typeof(MyService));
    	
    public static void Main()
    {
    		host.Open();
    		
    		Console.WriteLine("listening...");
    		
    		Console.Read();
    		
    		host.Close();
    	}
    }
