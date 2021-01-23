    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    public Form1()
    {
        InitializeComponent();
    
        timer.Interval = 5000;
        timer.Tick += timer_Tick;
        timer.Start();
    }
    
    private void timer_Tick(object sender, EventArgs e)
    {
        //runs in UI thread; code to go to next picture goes here
    }
    private void btnYes_Click(object sender, EventArgs e)
    {
        timer.Start();
    }
    private void btnNo_Click(object sender, EventArgs e)
    {
        timer.Start();
    }
