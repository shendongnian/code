    private void playerMoveOKButton_Click(object sender, EventArgs e)
    {
        //thread is merely used as an example
        //you could also use a BackgroundWorker or a task
        var thread = new Thread(NonUiLogic);
        thread.Start();
    }
    private void NonUiLogic()
    {
        ...
        //execute logic that doesn't touch UI
        ...
        BeginInvoke(ReversiT);
    }
    public void ReversiT() {...}
