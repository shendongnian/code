    public void Update_Sleep_UpdateAgain()
    {
       statusLabel.Text = "Running something";
       statusLabel.UpdateLayout();
       CallSomeAsyncProcess();
       Thread.Sleep(4000);
       statusLabel.Text = "Done Running";
    }
