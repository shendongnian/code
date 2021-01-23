    public class Global : NinjectWcfApplication
    {
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new ApplicationModule ());
        }
    }
