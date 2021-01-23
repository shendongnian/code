    public class NetworkStateMonitor
    {
        private System.Threading.Timer _timer;
        bool _wasConnected = false;
        public NetworkStateMonitor()
        {
            _timer = new System.Threading.Timer(OnPing, null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
        }
        
        public bool CheckInternetConnection() 
        {
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send("www.uic.co.il", 1000);
                if (reply.Status == IPStatus.Success)
                    return true;
            catch (PingException) 
            {
                return false;
            }
        }
    
        
        private void OnPing()
        {
            var newState = CheckInternetConnection();
            if (!newState && _wasConnected)
                ConnectionLost(this, EventArgs.Empty);
            else if (newState && !_wasConnected)
                Connected(this, EventArgs.Empty);
            _wasConnected = newState;
        }
        
        public event EventHandler ConnectionLost = delegate{};
        public event EventHandler Connected = delegate{};
    }
