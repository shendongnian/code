    public class NinjectBindings : Ninject.Modules.NinjectModule
     {
     public override void Load()
     {
     Bind<ISMSService>().To<MockSMSService>();
     }
     }
  
