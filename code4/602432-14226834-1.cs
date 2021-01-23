    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        var msgBox = new CustomMessageBox()
                     {
                         Caption = "foo",
                         Message = "bar",
                         LeftButtonContent = "baz",
                         RightButtonContent = "goo",
                         IsFullScreen = false,
    
                     };
    
    
        msgBox.Dismissed += (s, args) =>
        {
            DispatcherTimerHelper.InvokeReallySoon(() =>
            {
                new SmsComposeTask()
                {
                    Body = "foo",
                    To = "bar"
                }.Show();
            });
    
        };
    
        msgBox.Show();
    }
    
    
    public static class DispatcherTimerHelper
    {
        public static void InvokeReallySoon(Action action)
        {
            var t = new DispatcherTimer() {Interval = TimeSpan.FromMilliseconds(256)};
            t.Tick += (s, args) => action();
            t.Start();
        }
    } 
