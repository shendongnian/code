    private void DisplayMessage(string message) 
    { 
       ...
    }
    private delegate void SomeDelegateThatWillRunOnUIThread(string message);
    
    ...
    this.BeginInvoke(new SomeDelegateThatWillRunOnUIThread(DisplayMessage), yourMessage);
