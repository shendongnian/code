    System.Threading.ThreadPool.QueueUserWorkItem(obj =>
        {
            System.Threading.Thread.Sleep(5000);
            Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("after delay");
                });
        });
