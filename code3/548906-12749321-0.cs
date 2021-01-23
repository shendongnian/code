    public void InfoLabel(string value)
    {
        System.Windows.Forms.Timer timer = new Timer();
    
        timer.Interval = 1000;//or whatever the time should be.
        timer.Tick += (sender, args) =>
            {
                label1.Text = value;
                timer.Stop();
            };
        timer.Start();
    }
