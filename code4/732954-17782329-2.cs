    if (!Application.Current.Dispatcher.CheckAccess())
    {
        Application.Current.Dispatcher.BeginInvoke(
            new Action(() =>
            {
                Thread t = new Thread(() =>
                {
                    foreach (ListViewItem row in listView1.Items)
                    {
                        row.SubItems[0].Text = "Checking";
                        Thread.Sleep(2000);
                    }
                });
                t.Start();
            }),
            DispatcherPriority.ApplicationIdle,
            null);
    }
    else
    {
        Thread t = new Thread(() =>
        {
            foreach (ListViewItem row in listView1.Items)
            {
                row.SubItems[0].Text = "Checking";
                Thread.Sleep(2000);
            }
        });
        t.Start();
    }
