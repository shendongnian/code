    static class Parameters
    {
        private static IMyInterface _innerImplementaton;
    
        static Parameters()
        {
            // Resolve _innerImplementation here based on current AppDomain.
        }
        public static string GetValue(string arg)
        {
            return _innerImplementation.GetValue(arg);
        }
    }
