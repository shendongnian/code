    Timer tmr = null;
    private void StartTimer()
    {
        tmr = new Timer();
        tmr.Interval = 1000;
        tmr.Tick += new EventHandler(tmr_Tick);
        tmr.Enabled = true;
    }
    void tmr_Tick(object sender, EventArgs e)
    {
        myTextBox.Text = DateTime.Now.ToString();
    }
