    public new event MouseEventHandler MouseClick
    {
        add
        {
            base.MouseClick += value;
            foreach (Control control in Controls)
            {
                control.MouseClick += value;
            }
        }
        remove
        {
            base.MouseClick -= value;
            foreach (Control control in Controls)
            {
                control.MouseClick -= value;
            }
        }
    }
    public new event MouseEventHandler MouseDoubleClick
    {
        add
        {
            base.MouseDoubleClick += value;
            foreach (Control control in Controls)
            {
                control.MouseDoubleClick += value;
            }
        }
        remove
        {
            base.MouseDoubleClick -= value;
            foreach (Control control in Controls)
            {
                control.MouseDoubleClick -= value;
            }
        }
    }
    public new event EventHandler DoubleClick
    {
        add
        {
            base.DoubleClick += value;
            foreach (Control control in Controls)
            {
                control.DoubleClick += value;
            }
        }
        remove
        {
            base.DoubleClick -= value;
            foreach (Control control in Controls)
            {
                control.DoubleClick -= value;
            }
        }
    }
