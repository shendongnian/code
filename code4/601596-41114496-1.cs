    static public class Logger
    {
        static public void Log(MethodInfo method, object[] arguments, Exception exception)
        {
            Console.WriteLine("{0}({1}) exception = {2}", method.Name, string.Join(", ", arguments), exception.Message);
        }
    }
