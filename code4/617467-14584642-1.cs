    DateTime startTime;
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        label1.Text = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
    }
    
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        timer1.Stop();
        Properties.Settings.Default.TotalTime = (DateTime.Now - startTime);
        Properties.Settings.Default.Save();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        TimeSpan totalTime = Properties.Settings.Default.TotalTime;
        startTime = (totalTime == default(TimeSpan)) ?
            DateTime.Now : DateTime.Now.Subtract(totalTime);
        timer1.Start();
    }
