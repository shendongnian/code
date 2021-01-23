    public class DispatcherProxy<TOnline, TOffline, TContract>
        where TOnline : class, new()
        where TOffline : class, new()
        where TContract : class //isn't TContract an interface?
    {
        public TContract Instance { get; set; }
    
        public bool IsConnected { get; set; }
    
        public DispatcherProxy()
        {
            // Asume that I check if it's connected or not
            if (this.IsConnected)
                this.Instance = new TOnline() as TContract;
            else
                this.Instance = new TOffline() as TContract;
        }
    }
