    class NewClass
    {
     this._watcherTimer = new System.Timers.Timer();
     this._watcherTimer.Interval =  60000;
     this._watcherTimer.Enabled=False;
     this._watcherTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer_Tick);
     public void Start()
    {
     this._watcherTimer.Enabled=true;
    }
     private void Timer_Tick(object sender, EventArgs e)
        {
            Add();
            Multiply();
        }
    }
