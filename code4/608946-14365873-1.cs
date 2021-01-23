    public void AddAnimation(Button button)
    {
        var expandTimer = new System.Windows.Forms.Timer();
        var contractTimer = new System.Windows.Forms.Timer();
    
        expandTimer.Interval = 10;//can adjust to determine the refresh rate
        contractTimer.Interval = 10;
    
        DateTime animationStarted = DateTime.Now;
    
        //TODO update as appropriate or make it a parameter
        TimeSpan animationDuration = TimeSpan.FromMilliseconds(250);
        int initialWidth = 75;
        int endWidth = 130;
    
        button.MouseHover += (_, args) =>
        {
            contractTimer.Stop();
            expandTimer.Start();
            animationStarted = DateTime.Now;
            button.BackColor = Color.DimGray;
        };
    
        button.MouseLeave += (_, args) =>
        {
            expandTimer.Stop();
            contractTimer.Start();
            animationStarted = DateTime.Now;
            button.BackColor = Color.Red;
        };
    
        expandTimer.Tick += (_, args) =>
        {
            double percentComplete = (DateTime.Now - animationStarted).Ticks
                / (double)animationDuration.Ticks;
    
            if (percentComplete >= 1)
            {
                expandTimer.Stop();
            }
            else
            {
                button.Width = (int)(initialWidth +
                    (endWidth - initialWidth) * percentComplete);
            }
        };
    
        contractTimer.Tick += (_, args) =>
        {
            double percentComplete = (DateTime.Now - animationStarted).Ticks
                / (double)animationDuration.Ticks;
    
            if (percentComplete >= 1)
            {
                contractTimer.Stop();
            }
            else
            {
                button.Width = (int)(endWidth -
                    (endWidth - initialWidth) * percentComplete);
            }
        };
    }
