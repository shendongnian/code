    public void Update_Sleep_UpdateAgain()
    {
       statusLabel.Text = "Running something";
       statusLabel.UpdateLayout();
       CallSomeAsyncProcess(); //Or some other processing going on
       Thread.Sleep(4000);
       statusLabel.Text = "Done Running";
    }
