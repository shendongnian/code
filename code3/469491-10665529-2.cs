    private Timer tm;
    private void Form1_Load(object sender, EventArgs e)
    {
        tm = new Timer();
        tm.Enabled = true;
        tm.Interval = 10 * 1000; // 10 seconds
        tm.Tick += new EventHandler(tm_Tick);
        tm.Start(); // start the timer
    }
    private void tm_Tick(object sender, EventArgs e)
    {
        Form2 frm = new Form2();
        frm.Show();
        this.Hide();
        tm.Stop(); // stop the timer, do not process anymore
    }
