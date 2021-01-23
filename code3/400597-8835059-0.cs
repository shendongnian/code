    private void FireButtonClick(object sender, EventArgs e)
    {
        Thread worker = new Thread(new ThreadStart(delegate()
        {
            //your code
        });
        worker.IsBackground = true; //so it does not block the app from being closed
        worker.Start();
    }
