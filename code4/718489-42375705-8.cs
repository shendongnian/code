    public class NinjectBindings : Ninject.Modules.NinjectModule
     {
     public override void Load()
     {
    #if DEBUG
     Bind<ISMSService>().To<MockSMSService>();
    #else
     Bind<ISMSService>().To<SMSService>();
    #endif
    
    }
     }
  
