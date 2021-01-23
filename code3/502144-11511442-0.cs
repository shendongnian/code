    Timer timer;
    bool resetting = false;
    Form2 frm2;
    public Form1()
    {
        InitializeComponent();
        frm2 = new Form2();
        frm2.Show();
        timer = new Timer();
        timer.Interval = 50;
        timer.Tick+=new EventHandler(timer_Tick);
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        timer.Stop();
        resetting = false;
    }
    
    private void Form1_Activated(object sender, EventArgs e)
    {
        if (!resetting)
        {
            timer.Start();
            frm2.Focus();
            this.Focus();
            resetting = true;
        }
    }
