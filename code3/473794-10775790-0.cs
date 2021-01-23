    static class Parameters
    {
        private static IMyInterface _innerImplementaton;
    
        static Parameters()
        {
            // Resolve _innerImplementation here based on current AppDomain, likely have to be hardcoded.
        }
    }
