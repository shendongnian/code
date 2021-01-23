    System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    // form constructor
    public myForm() 
    {
        myTimer.Interval = 1000;    // or whatever you need it to be
        myTimer.Tick += new EventHandler(TimerEventProcessor);   
    }
    private void myMouseHover(object sender, EventArgs e) 
    {
         this.prevPanel.Visible = true;
         this.nextPanel.Visible = true;
         myTimer.Start();
     }
    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
         myTimer.Stop();
         this.prevPanel.Visible = false;
         this.nextPanel.Visible = false;
    }
