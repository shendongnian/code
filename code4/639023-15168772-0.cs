    [assembly: WebActivator.PreApplicationStartMethod(typeof(SomeNamespace.AppStart), "Start")]
    
    namespace SomeNamespace
    {
    
        public static class AppStart
        {
            /// <summary>
            /// Will run when the application is starting (same as Application_Start)
            /// </summary>
            public static void Start() 
            {
                ... put your initialization code here
            }
        }
    }
