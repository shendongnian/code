    public System.Threading.Timer MyTimer { get; set; }
    
    this.MyTimer = new System.Threading.Timer(new TimerCallback(MyTimer_CallBack), null, 1000, 1000);
    
    void MyTimer_CallBack(object State)
    {
    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (System.Threading.ThreadStart)delegate()
    {
      ApplicationVariables.ServerDateTime = CurrentDT = CurrentDT.AddSeconds(1); 
    });
    }
