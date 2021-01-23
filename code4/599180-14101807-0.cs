    public static void RunDelayedOnUiThread(Action action)
    {
         Deployment.Current.Dispatcher.BeginInvoke(() =>
         {
             var timer = new DispatcherTimer 
                         { 
                             Interval = TimeSpan.FromMilliseconds(1) 
                         };
             timer.Tick += (sender, args) =>
             {
                 timer.Stop();
                 action();
             };
             timer.Start();
         });
    }
