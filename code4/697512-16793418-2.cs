    public class PortalNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ControllerContextProvider>().ToSelf().InRequestScope();
        }
    }
