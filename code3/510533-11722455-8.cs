    public class Global : NinjectWcfApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new ApplicationModule ());
            
            // add some service specific bindings, for example authorization
            // service has also some other small services that i call providers 
            // so ex Service 1 : has Iprovider1 Iprovider2 Iprovider3 
            kernel.Bind<IProvider1>().To<Provider1>();
            kernel.Bind<IProvider2>().To<Provider2>();
            kernel.Bind<IProvider3>().To<Provider3>();
            
            return kernel;
        }
    }
