    using System;
    
    [assembly: WebActivator.PreApplicationStartMethod(typeof(MyDependency), "Initialize")]
    public static class MyDependency
    {
        public static void Initialize()
        {
            // Perform some I/O...
        }
    }
