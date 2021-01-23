    protected override void OnClosing(CancelEventArgs e)
    {
        e.Cancel = false;
        new Thread(() => { 
            Thread.Sleep(5000); //replace this line to save some data.....
            MessageBox.Show("EXITED"); 
        }).Start();
        base.OnClosing(e);
    }
