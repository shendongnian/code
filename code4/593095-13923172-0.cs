    public interface ILogger
    {
       void Log(string text);
    }
    
    public class ConsoleLogger
    {
       public void Log(string text) { Console.WriteLine(text); }
    }
    
    public class TraceWriter
    {
       private ILogger log;
       
       // Default behaviour
       public TraceWriter () : 
         this(new ConsoleLogger()) { }
       
       // User specified implementation
       public TraceWriter ( ILogger logger )
       {
          this.log = logger;
       }
    }
