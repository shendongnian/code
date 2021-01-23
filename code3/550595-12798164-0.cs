    Timer timer = new Timer { Interval = 100 };
    private void button1_MouseDown(object sender1, MouseEventArgs e1)
    {
           
        timer.Enabled = true;
        timer.Tick += (sender, e) =>
                            {
                                // what you want
                                progressBar1.Value = progressBar1.Value + 1;
                            };
    }
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
        timer.Enabled = false;
    }
