    int signal = 0;
    System.Timers.Timer t = new System.Timers.Timer(3000);
    private void Form1_Load(object sender, EventArgs e)
    {
        //----------------------- other parts of code ---------------------
        // at last
        t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
        t.Start();
    }
    void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (signal == 0)
            return;
        t.Stop();
        MessageBox.Show("You clicked: " + signal + " before " + t.Interval + " Seconds");
        signal = 0;
        t.Start(); //move this to top of msgbox if you want timer to be reset right after poppin the msgbox.
    }
    private void button1_Click(object sender, EventArgs e)
    {
        signal = 1;
        t.Stop();
        t.Start();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        signal = 2;
        t.Stop();
        t.Start();
    }
    private void button3_Click(object sender, EventArgs e)
    {
        signal = 3; 
        t.Stop();
        t.Start();
    }
