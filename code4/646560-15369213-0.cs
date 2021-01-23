    private bool _traffic;
    public event System.EventHandler TrafficDataChanged;
    
    protected virtual void OnTrafficChanged()
    { 
         if (TrafficDataChanged != null) TrafficDataChanged(this,EventArgs.Empty); 
    }
    
    public bool Traffic
    {
        get
        {
             return _traffic;
        }
    
        set
        {
             _traffic=value;
             OnTrafficChanged();
        }
     }
