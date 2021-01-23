    public static void RunWithMargueProgress(this Action action, ToolStripProgressBar progressBar)
    {
        progressBar.Style = ProgressBarStyle.Marquee;            
        progressBar.MarqueeAnimationSpeed = 30;
            
        Task.Factory.StartNew(action)
            .ContinueWith(t =>
                               {
                                   progressBar.MarqueeAnimationSpeed = 0;
                                   progressBar.Style = ProgressBarStyle.Continuous;                                      
                               }, TaskScheduler.FromCurrentSynchronizationContext());
    }
