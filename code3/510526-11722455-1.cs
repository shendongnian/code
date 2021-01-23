    public class YourWebApplication : NinjectHttpApplication
    {
      public override IKernel CreateKernel()
      {
         return new StandardKernel(new ApplicationModule ());
      }
    }
