    public ControlDecorator(Control c)
    {
        this.Control = c;
        this.Controls.Add(c);
        this.Control.MouseClick += new MouseEventHandler(Control_MouseClick);
    }
