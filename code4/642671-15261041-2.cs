    public interface IWebHost 
    { 
       string DoSomething(string input); 
    } 
    
    public class FooManager 
    {
       private IWebHost _host; 
       public FooManager(IWebHost host)
       {  
          _host = host; 
       } 
    
       public void Process()
       { 
          // do something with _host 
       }
    } 
