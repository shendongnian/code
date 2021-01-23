    private void sql_QueryCompleted(QueryResult qr)
    {
        Dispatcher.BeginInvoke(new Action(() => { 
            lstStatus.Items.Clear();
            lstStatus.Items.Add(qr.RuntimeTotal);
            //... and some more...
        });
    }
