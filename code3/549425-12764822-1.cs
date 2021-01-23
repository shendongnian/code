    private void Form1_Load(object sender, EventArgs e)
    {
        Light_timer = new Timer();
        Light_timer.Tick += new EventHandler(TimerElapsed);
        Light_timer.Interval = 1000;
    }
    private void TimerElapsed(object sender, EventArgs e)
    {
        counter++;
        if (counter == 1)
        {
            pbRed.Visible = true;
            pbAmber.Visible = false;
            pbGreen.Visible = false;
        }
        else if (counter == 2)
        {
            pbRed.Visible = true;
            pbAmber.Visible = true;
            pbGreen.Visible = false;
        }
        else if (counter == 3)
        {
            pbRed.Visible = false;
            pbAmber.Visible = false;
            pbGreen.Visible = true;
        }
        else if (counter == 4)
        {
            pbRed.Visible = false;
            pbAmber.Visible = true;
            pbGreen.Visible = false;
        }
        else if (counter == 5)
        {
            pbRed.Visible = true;
            pbAmber.Visible = false;
            pbGreen.Visible = false;
        }
        else
        {
            counter = 0;
            Light_timer.Stop();
        }
    }
    private void rbStart_CheckedChanged(object sender, EventArgs e)
    {
        Light_timer.Start();
    }
    private void rbStop_CheckedChanged(object sender, EventArgs e)
    {
        Light_timer.Stop();
        pbRed.Visible = false;
        pbAmber.Visible = false;
        pbGreen.Visible = false;
    }
