    Timer timer1= null;
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.closeable == true)
        {
            Application.Exit();
        }
        else
        {
            if (timer1 == null)
            {
                timer1 = new Timer();
                timer1.Tick += (s, ev) => { closeable = IsTaskDone(); Close(); };
                timer1.Interval = (int)new TimeSpan(0, 0, 4).TotalMilliseconds;
                timer1.Start();
            }
            e.Cancel = true;
        }
    }
    private bool IsTaskDone()
    {
        // TODO: returns true if the task is completed
    }
