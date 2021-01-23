    public class NinjectBindings : Ninject.Modules.NinjectModule
     {
     public override void Load()
     {
    #if DEBUG
     Bind<ISMSService>().To<MockSMSService>();
     Bind<INotifierService>().To<MockNotifierService>();
    #else
     Bind<ISMSService>().To<SMSService>();
     Bind<INotifierService>().To<NotifierService>();
    #endif
    
    }
     }
