    // In your provided library
    public abstract class Client 
    {
       public void Run()
       {
       
          OpenConnection();
          
          WaitForInitMsg();
          
          OnInit(); // notify subclass
          
          SendInitAckMsg();
          
          WaitForConfigMsg();
          
          OnConfig(); // notify subclass
          
          SendConfigAckMsg();
          
          // etc, etc
          
       }      
    
       protected abstract void OnInit() {}
       
       protected abstract void OnConfig() {}
       
    }
    
    // customer/client uses the functionality like this
    public class ConsoleClient : Client
    {
       protected void OnInit() 
       {
          Console.WriteLine("Initialized");
       }
       
       protected void OnConfig() 
       {
          Console.WriteLine("Configured");
       }
       
    }
    
    public class MainClass 
    {    
       static void Main(string[] args)    
       {
          ConsoleClient client = new ConsoleClient();
          client.Run();
       }
    }
