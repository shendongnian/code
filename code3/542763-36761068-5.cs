    public partial class App : Application
    {
        public App()
        {
            ClickOnceUtil clickonceutil = new ClickOnceUtil();
            clickonceutil.CheckAndUpdate();
        }
    }
