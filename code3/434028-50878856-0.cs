            new Thread(() =>
            {
            Thread.CurrentThread.IsBackground = false;
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate {
              //Your Code here.
            }, null);
            }).Start();
