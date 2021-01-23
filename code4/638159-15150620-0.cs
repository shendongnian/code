    public static class DI
    {
        private static IKernel _kernel;
        private static Boolean _kernelLoaded = false;
        public static T Resolve<T>() where T : class
        {
            ...
            var a = _kernel.Get<T>();
            return a;
        }
       ...
    }
