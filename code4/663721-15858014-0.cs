    public interface ILog
    {
       void WriteMessage(string message);
    }
    
    public class ConsoleLogger : ILog
    {
       public void WriteMessage(string message)
       {
          Console.WriteLine(message);
       }
    }
    
    public class MessageBoxLogger : ILog
    {
       public void WriteMessage(string message)
       {
          MessageBox.Show(message);
       }
    }
    
    public void DoSomethingInteresting(ILog logger)
    {
       logger.WriteMessage("I'm doing something interesting!");
    }
