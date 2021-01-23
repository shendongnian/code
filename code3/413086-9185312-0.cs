    public class NinjectServiceLocator
    {
        private readonly IKernel kernel;
        public NinjectServiceLocator()
        {
            kernel = new StandardKernel(new MyMvvmModule());
        }
        public ResultViewModel ResultViewModel
        {
            get { return kernel.Get<ResultViewModel>(); }
        }
    }
