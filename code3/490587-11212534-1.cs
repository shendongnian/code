    bool reallyClose;
    protected override void OnClosing(CancelEventArgs e)
    {
        if (!reallyClose)
        {
            e.Cancel = true;
            Hide();
        }
        base.OnClosing(e);
    }
