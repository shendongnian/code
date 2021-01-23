    private void Form1_Load(object sender, EventArgs e)
    {
        label1.Text = "Loading . . .";
    
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 1000;
    
        timer.Tick += (s, args) =>
        {
            label1.Text = "Done!";
        };
    
        timer.Start();
    }
