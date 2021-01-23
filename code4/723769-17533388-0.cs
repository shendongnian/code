    public void ClickHandler()
        {
            MainWindow.IsEnabled = false;
            Task.Factory.StartNew(() =>
                {
                    // Length work goes here
                }).ContinueWith((result) =>
                    {
                        Dispatcher.BeginInvoke(() =>
                            {
                                MainWindow.IsEnabled = true;
                            });
                    });
        }
