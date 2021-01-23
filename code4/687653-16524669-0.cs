    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        RootFrame.RemoveBackEntry();
        base.OnBackKeyPress(e);
    }
