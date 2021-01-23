    public class mydll
    {
        // etc.. blah blah
        public T callfromdll<T>(string commandName, int requiredArgs, Func<int, T> method)
        {
            int x = SomeComplexFunction(commandName, requiredArgs);
            return method(x);
        }
    }
    -- within an application that's refrancing the above dll --
    public someclass
    {
        public void test()
        {
            // etc.. stuff here
            mydll m = new mydll();
            var result = m.callfromdll("callthisexternally", 0, new Func(callthisexternally));
            //result contains "i was called, and my result was #" and where # is replace with the number passed in to callthisexternally
        }
        // the function to be called externally
        public string callthisexternally(int x)
        {
            // do stuff
            return "i was called, and my result was " + x;
        }
    }
