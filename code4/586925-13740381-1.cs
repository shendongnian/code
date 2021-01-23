    private Timer tmr;
    private int scrll { get; set; }
    void Form1_Load(object sender, EventArgs e)
    {
        tmr = new Timer();
        tmr.Tick += new EventHandler(this.TimerTick);
        tmr.Interval = 200;
        tmr.Start();
    }
    private void TimerTick(object sender, EventArgs e)
    {
        ScrollLabel();
    }
    private void ScrollLabel()
    {
        string strString = "This is scrollable text...This is scrollable text...This is scrollable text";
        scrll = scrll + 1;
        int iLmt = strString.Length - scrll;
        if (iLmt < 20)
        {
            scrll = 0;
        }
        string str = strString.Substring(scrll, 20);
        label1.Text = str;
    }
    private void label1_Click(object sender, EventArgs e)
    {
        ScrollLabel();
    }
