    #region Form1_Load()
    private void Form1_Load(object sender, EventArgs e)
    {
        Load();
        //this line 
        InitTimer(OtherLoad);
    }
    #endregion
    #region Timer()
    private void OtherLoad(object sender, EventArgs e)
    {...}
    public void InitTimer(EventHandler _method)
    {
        System.Windows.Forms.Timer timer1;
        timer1 = new System.Windows.Forms.Timer();
        timer1.Tick += _method;
        timer1.Interval = 5000; // in miliseconds
        timer1.Start();
    }
    #endregion
