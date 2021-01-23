    System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    private void Configure_Load(object sender, EventArgs e)
    {
        endpointBox.KeyUp += EndpointBox_KeyUp;
        myTimer.Tick +=new EventHandler(OnTimedEvent);       //EDIT: should not be `ElapsedEventHandler`  
        myTimer.Interval=750;   
    }
    
    void EndpointBox_KeyUp(object sender, KeyEventArgs e)
    {    
        myTimer.Stop();
        myTimer.Start();   
    }
    
    
     private void OnTimedEvent(Object myObject,EventArgs myEventArgs) 
    {
          myTimer.Stop();
          TestHTTP200(endpointBox.Text);
    }
