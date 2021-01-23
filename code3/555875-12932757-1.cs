    public class Plugin
        : IMvxPlugin
        , IMvxServiceProducer
    {
        #region Implementation of IMvxPlugin
        public void Load()
        {
            // alpha registered as a singleton
            this.RegisterServiceInstance<IAlphaService>(new MyAlphaService());
            // page registered as a type
            this.RegisterServiceType<IPageService, MyPageService>();
        }
        #endregion
    }
