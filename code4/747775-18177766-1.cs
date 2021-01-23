    protected override void OnClosing(CancelEventArgs e)
    {
        if (!_Next)
        {
            e.Cancel = true;
        }
    }
