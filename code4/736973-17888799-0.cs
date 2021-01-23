    public interface IConsole
    {
        string ReadLine();
    }
    
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
