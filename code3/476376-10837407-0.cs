    // UserControl.cs
    public event EventHandler Close;
    void OkChangeDataRootPathExecute()
    {
        if (Close != null)
            Close(this, EventArgs.Empty);
    }
    // Window.cs
    void UserControl_Close(object sender, EventArgs e)
    {
        Close();
    }
