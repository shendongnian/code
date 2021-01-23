        System.Threading.ThreadPool.QueueUserWorkItem(obj =>
        {
            // Do some work
            for (int i = 0; i < 1000; i++)
                Math.Sin(i);
            // Get back to the UI thread
            App.Current.MainWindow.Dispatcher.BeginInvoke(
                new Action(delegate 
                { 
                    block.Text = "Done!"; 
                }));
        });
