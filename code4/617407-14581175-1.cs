    void timer1_Tick(object sender, EventArgs e)
    {
        if (endTime < DateTime.Now)
        {
           MessageBox.Show("Time is out!");
           timer1.Stop();
           return;
        }
        timeLabel.Text = (endTime - DateTime.Now).ToString(@"hh\:mm");
    }
