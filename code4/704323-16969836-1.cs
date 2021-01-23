    // Class definition ...
    public TabPage PreviousTab { get; private set;}   
    private void Deselecting(object sender, TabControlCancelEventArgs e)
    {
    if (e.TabPage != null)
    PreviousTab = e.TabPage;
    }
