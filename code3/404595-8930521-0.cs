    public abstract class Data
    {
        private bool connected;
        public bool Connected
        {
            get { return connected; }
        }
    
        public void Connect()
        {
            OnConnect();
            connected = true;
        }
        public void Disconnect()
        {
            if (connected)
            {
                OnDisconnect();
                connected = false;
            }
        }
        protected virtual void OnConnect() { }
        protected virtual void OnDisconnect() { }
    }
    
