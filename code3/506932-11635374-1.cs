    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => doStuffInBackground())
            .ContinueWith(task => updateUI(), TaskScheduler.FromCurrentSynchronizationContext());
    }
    
    private void updateUI()
    {
        throw new NotImplementedException();
    }
    
    private void doStuffInBackground()
    {
        throw new NotImplementedException();
    }
