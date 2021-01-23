    private void ShowStatusMessage(string message)
    {
        StatusMessage.Content = message;
        var timer = new System.Timers.Timer();
        timer.Interval = 2000; //2 seconds
        timer.Elapsed += delegate(object sender, System.Timers.ElapsedEventArgs e)
        {
            //stop the timer
            timer.Stop();
            //remove the StatusMessage text using a dispatcher, because timer operates in another thread
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusMessage.Content = "";
            }));
        };
        timer.Start();
    }
