    void timer_Tick(object sender, EventArgs e)
    {
        ((Timer)sender).Interval = new TimeSpan(0, 0, 5);
        MessageBox.Show("!!!");
    }
