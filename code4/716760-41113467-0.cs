    public Constructor() 
    {
        SetStyle(ControlStyles.Selectable, true);
        TabStop = true;
    }
    protected override void OnMouseDown(MouseEventArgs e) 
    {
        Focus();
        base.OnMouseDown(e);
    }
