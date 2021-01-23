    protected override void OnControlAdded(ControlEventArgs e)
    {
        e.Control.DoubleClick += Control_DoubleClick;
        e.Control.ControlAdded += OnControlAdded;// add this line
        base.OnControlAdded(e);
    }
    // add this method
    private void OnControlAdded(object sender, ControlEventArgs e)
    {
        e.Control.DoubleClick += Control_DoubleClick;
    }
