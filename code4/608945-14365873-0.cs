    public  void AddAnimation(Button button)
    {
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 10;//can adjust to determine the refresh rate
    
        DateTime animationStarted = DateTime.Now;
    
        //TODO update as appropriate or make it a parameter
        TimeSpan animationDuration = TimeSpan.FromMilliseconds(250);
        int initialWidth = 75;
        int endWidth = 130;
    
        button.MouseHover += (_, args) =>
        {
            timer.Start();
            animationStarted = DateTime.Now;
            button.BackColor = Color.DimGray;
        };
    
        button.MouseLeave += (_, args) =>
        {
            timer.Stop();
            button.Width = initialWidth;
            button.BackColor = Color.Red;
        };
    
        timer.Tick += (_, args) =>
        {
            double percentComplete = (DateTime.Now - animationStarted).Ticks
                / (double) animationDuration.Ticks;
    
            //textBox1.Text += percentComplete.ToString();
    
            if (percentComplete >= 1)
            {
                timer.Stop();
            }
            else
            {
                button.Width = (int)(initialWidth +
                    (endWidth - initialWidth) * percentComplete);
            }
    
        };
    }
