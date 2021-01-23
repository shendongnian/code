    static class Parameters
    {
        private static IParametersProvider _provider;
    
        static Parameters()
        {
            // Resolve _provider here based on current AppDomain.
            _provider = new ParametersProvider();
        }
        public static string GetValue(string arg)
        {
            // The interface doesn't necessarily need the same method signatures
            // but by default it will likely start out that way.
            return _provider.GetValue(arg);
        }
    }
