    public void FunctionA()
    {
        Task.Delay(5000)
        .ContinueWith(t => 
        {
            MessageBox.Show("Waiting Complete");
        });
    }
