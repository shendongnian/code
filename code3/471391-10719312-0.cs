            var opThread = new Thread(delegate()
            {
                //your lengthy operation
                tbReadToMe.Dispatcher.Invoke(new Action(delegate
                {
                    tbReadToMe.Text = "Pause";
                }));
                //your lengthy operation
                tbReadToMe.Dispatcher.Invoke(new Action(delegate
                {
                    tbReadToMe.Text = "etc...";
                }));
            });
            opThread.Start();
