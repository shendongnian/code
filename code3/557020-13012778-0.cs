    public class ClientInfo
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class BaseClient
    {
        protected ClientInfo _info;
    
        private static BaseClient _instance;
        private static readonly object padlock = new object();
    
        public static BaseClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new BaseClient(true);
                    }
                    return _instance;
                }
            }
        }
        public ClientInfo Info
        {
            get
            {
                if(_info == null)
                {
                    _info = new ClientInfo();
                }
                return _info;
            }
        }
    
        public void SetInfo(string url, string username, string password)
        {
            Info.Url = url;
            Info.Username = username;
            Info.Password = password;
        }
    
        public string GetVersion()
        {
            //MyService is a simple static service provider
            return MyService.GetVersion(Info.Url, Info.Username, Info.Password);
        }
    }
    
    public class Advanced : BaseClient
    {
        private static AdvancedClient _instance;
        private static readonly object padlock = new object();
    
        public static AdvancedClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new AdvancedClient(true);
                        _instance._info = BaseClient.Instance.Info;
                    }
                    return _instance;
                }
            }
        }
    
        public void DoAdvancedMethod()
        {
            MyService.DoSomething(Info.Url, Info.Username, Info.Password);
        }
    }
