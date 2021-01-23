    Timer timer1 = null;
    public MainForm()
    {
        InitializeComponent();
    
        timer1 = new Timer();
        timer1.Interval = (int)new TimeSpan(0, 0, 4).TotalMilliseconds;
        timer1.Tick += (s, ev) => { timer1.Stop();  closeable = IsTaskDone(); Close(); };
    }
    
    public bool closeable = true;
    public void setCloseable()
    {
        this.closeable = false;
    }
    
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.closeable == true)
        {
            Application.Exit();
        }
        else
        {
            timer1.Start();
    
            e.Cancel = true;
        }
    }
    private bool IsTaskDone()
    {
        // TODO: returns true if the task is completed
    }
