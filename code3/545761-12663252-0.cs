    int time = 0;
    private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        btnStartAdventures.Text = "Start Adventure";
        btnStartAdventures.Enabled = true;
        if (e.Error != null)
        {
            MessageBox.Show(e.Error.Message);
            return;
        }
        if (e.Cancelled)
        {
            lblStatusValueInAdventures.Text = "Cancelled...";
        }
        else
        {
            lblStatusValueInAdventures.Text = "Completed";
            timer1.Interval = 1000; //<--- Tick each second, you can change this.
            timer1.Enabled = true;
            timer1.Start();
            // MessageBox.Show("start timer");
        }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        lblTimer.Text = (time + 1).ToString();
    }
    private void button_Cancel_Click(object sender, EventArgs e)
    {
        //MessageBox.Show("end timer");
        timer1.Enabled = false;
        timer1.Stop();
        lblTimer.Text = "0";
        btnStartAdventures.PerformClick();
    }
