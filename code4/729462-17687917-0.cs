    public class mydll
    {
        // etc.. blah blah
        public T callfromdll<T>(string commandName, int requiredArgs, Func<T> method)
        {
            // do stuff
            // now invoke the method
            return method();
        }
    }
