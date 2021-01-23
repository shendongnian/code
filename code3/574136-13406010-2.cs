    public class ConsoleService : IConsoleService
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
