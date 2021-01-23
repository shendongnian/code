    public class YourWebApplication : NinjectHttpApplication
    {
      public override IKernel CreateKernel()
      {
         var kernel = new StandardKernel(new ApplicationModule ());
      
         // add some UI specific bindings, for example authorization
         kernel.Bind<IAuthProvider>().To<AuthProvider>();
         // binding between service contract and implementation/client
         kernel.Bind<IServiceContract>().To<WcfServiceClient>();
         return kernel;
      }
    }
