    public class Unit
    {
        private readonly object _syncRoot = new object();
        private bool _status;
    
        public event EventHandler OnChanged;    
            
        public bool Status
        {
            get
            {
                lock (_syncRoot)
                {
                    return _status;    
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _status = value;
                    if (_status && OnChanged != null)
                    {
                        OnChanged.Invoke(this, null);        
                    }
                }
            }
        }
      
        public void Process()
        {
            Thread.Sleep(1000);
            Status = true;
        }
    }
