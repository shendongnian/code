    protected override void OnClosing(CancelEventArgs e)
    {
       // ... show message box
       if (/* wants to save*/)
       {
           // Cancel closing, the player does not want to exist
           e.Cancel = true;
       }
       base.OnClosing(e);
    }
