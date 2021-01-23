    public class MyTimerHolder
        {
            private static Lazy<MyTimerHolder> _instance = new Lazy<MyTimerHolder>(() => new MyTimerHolder());
            private readonly TimeSpan _checkPeriod = TimeSpan.FromSeconds(3);
            private IHubContext _hubProxy;
            // Threaded timer
            private Timer _timer;
    
            public MyTimerHolder()
            {
                _timer = new Timer(CheckDB, null, _checkPeriod, _checkPeriod);
            }
    
            public void BroadcastToHub(IHubContext context)
            {
                _hubProxy = context;
            }
    
            public void CheckDB(object state)
            {
                if (_hubProxy != null)
                {
                    // Logic to check your database
    
                    _hubProxy.Clients.All.foo("Whatever data you want to pass");
                }
            }
    
            public static MyTimerHolder Instance
            {
                get
                {
                    return _instance.Value;
                }
            }
        }
