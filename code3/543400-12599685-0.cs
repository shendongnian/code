    public class StatusMessageChangedEventArgs : EventArgs
    {
        public StatusMessageChangedEventArgs(string message)
        {
            Message = message;
        }
  
        public string Message
        {
            get;
            private set;
        }
    }
    public event<StatusMessageChangedEventArgs> StatusMessageChanged;
    protected void OnStatusMessageChanged(string message)
    {
        if (StatusMessageChanged != null)
            StatusMessageChanged(this, new StatusMessageChangedEventArgs(message));
    }
