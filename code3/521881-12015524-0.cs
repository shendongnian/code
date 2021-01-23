    private bool _programmaticClose;
    // Call this instead of calling Close()
    private void ShutDown()
    {
        _programmaticClose = true;
        Close();
    }  
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing();
        _programmaticClose = false;
    }
