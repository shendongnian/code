    public sealed class MyServiceHost : ServiceHost
    {
        public MyServiceHost() : base() 
        {
            MyServiceLocator.SetAsDefaultServiceLocator();
        }
    }
