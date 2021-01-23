    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyApi : IMyApi
    {
        public string SayHello(string s)
        {
            return "Hello " + s;
        }
    }
    static void Main()
    {
        var api = new MyApi();
        var svcHost = new ServiceHost(api, new Uri("net.tcp://localhost:12345/MyService"));
        svcHost.Open();
        Thread.CurrentThread.Join();
    }
