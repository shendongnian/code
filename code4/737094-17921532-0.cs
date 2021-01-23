        // Constructor call will only be allowed for target DEBUG 
        public class Protect : IDisposable
        {
    #if DEBUG
            [Obsolete("error", false)]
    #else
            [Obsolete("error", true)]
    #endif
            public Protect()
            {
    
            }
    
            public void Dispose()
            {
            }
        }
