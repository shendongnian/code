            Thread t = new Thread(() =>
            {
                foreach (ListViewItem row in listView1.Items)
                {
                    if (!Dispatcher.CurrentDispatcher.CheckAccess())
                    {
                        Dispatcher.CurrentDispatcher.BeginInvoke(
                            new Action(() =>
                            {
                                row.SubItems[0].Text = "Checking";
                            }),
                            DispatcherPriority.ApplicationIdle,
                            null);
                    }
                    else
                    {
                        row.SubItems[0].Text = "Checking";
                    }
                    
                    Thread.Sleep(2000);
                }
            });
            t.Start();
