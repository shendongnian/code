    private void button_Click(object sender, RoutedEventArgs e)
    {
        new Thread(SyncProcces).Start();
    }
    private void SyncProcces()
    {
        string val1 = null, val2 = null;
        //here is the problem 
        val1 = textBox1.Text;//access UI in another thread
        val2 = textBox2.Text;//access UI in another thread
        localStore = new LocalStore(val1);
        remoteStore = new RemoteStore(val2);
    }
