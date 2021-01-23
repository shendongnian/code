            Thread t = new Thread(() =>
            {
                if (!Dispatcher.CurrentDispatcher.CheckAccess())
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(
                        new Action(() =>
                        {
                            foreach (ListViewItem row in listView1.Items)
                            {
                                row.SubItems[0].Text = "Checking";
                                Thread.Sleep(2000);
                            }
                        }),
                        DispatcherPriority.ApplicationIdle,
                        null);
                }
                else
                {
                    foreach (ListViewItem row in listView1.Items)
                    {
                        row.SubItems[0].Text = "Checking";
                        Thread.Sleep(2000);
                    }
                }
            });
            t.Start();
