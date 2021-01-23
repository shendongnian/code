    private DateTime _lastKeyDownTime;
    private const int interval = 100;
    
    private void LoadHandler(object sender, EventArgs e)
    {
     // start Threading.Timer or some other timer
     System.Threading.Timer timer = new System.Threading.Timer(DoSomethingDefault, null, 0, interval);
    }   
    
    private void DoSomethingDefault(object state)
    {
        if ((DateTime.Now - _lastKeyDownTime).TotalMilliseconds < interval)                            
            return;            
    
        // modify UI via Invoke
    }
    
    private void KeyDown(object sender, KeyEventArgs e)
    {
        _lastKeyDownTime = DateTime.Now;
    
        switch (e.KeyCode)
        {
            // directly modify UI
        }  
    }
