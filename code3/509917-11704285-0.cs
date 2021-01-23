    private int signal = 0;
    public Form1()
    {
        InitializeComponent();
        Timer t = new Timer(3000);    //or even better, under form load.
        t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
        t.Start();
    }
    void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (singal == 0)
            return; //handle logic here
        MessageBox.Show("You clicked : " + signal + "before " + ((Timer)sender).Interval + " Seconds");
        ((Timer)sender).Dispose();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        signal = 1;
    }
    private void button2_Click(object sender, EventArgs e)
    {
        signal = 2;
    }
    private void button3_Click(object sender, EventArgs e)
    {
        signal = 3;
    }
