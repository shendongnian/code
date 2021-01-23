    class NinjectKernelSingleton
    {
        private static YourKernel _kernel;
        public static YourKernel Kernel
        {
            get { return _kernel ?? (_kernel = new YourKernel()); }
        }
    }
    public class YourKernel
    {
        private IKernel _kernel;
        public YourKernel()
        {
            _kernel = InitKernel();
        }
        private IKernel InitKernel()
        {
            //Ninject init logic goes here
        }
        public T Resolve<T>() 
        {
            return _kernel.Get<T>();
        }
    }
