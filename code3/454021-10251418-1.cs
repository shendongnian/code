    public class Global : NinjectWcfApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            return kernel;
        }
    }
