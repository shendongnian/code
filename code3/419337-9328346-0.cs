    System.Threading.SynchronizationContext sync;
    private void Form1_Load(object sender, System.EventArgs e)
    {
    	sync = SynchronizationContext.Current;
    	System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer { Interval = 1000 };
    	tm.Tick += tm_Tick;
    	tm.Start();
    }
    
    //Handles tm.Tick
    private void tm_Tick(object sender, System.EventArgs e)
    {
    	sync.Post(dopost, DateAndTime.Now.ToString());
    }
    
    public void dopost(string txt)
    {
    	Label1.Text = txt;
    }
