    [assembly: WebActivator.PreApplicationStartMethod(typeof(WebAppInitializer), "Start")]
    namespace FooBar
    {
        public static class WebAppInitializer
        {
            public static void Start()
            {
                // PROCESS ON APPLICATION START EVENT
            }
        }
    }
