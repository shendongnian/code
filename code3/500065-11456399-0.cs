    private void addHandlers()
    {
        foreach (TextBox control in Controls.OfType<TextBox>())
        {
            control.TextChanged += new EventHandler(OnContentChanged);
        }
        foreach (ComboBox control in Controls.OfType<ComboBox>())
        {
            control.SelectedIndexChanged += new EventHandler(OnContentChanged);
        }
        foreach (CheckBox control in Controls.OfType<CheckBox>())
        {
            control.CheckedChanged += new EventHandler(OnContentChanged);
        }
    }
    
    protected void OnContentChanged(object sender, EventArgs e)
    {
        if (ContentChanged != null)
            ContentChanged(this, new EventArgs());
    }
    
    public event EventHandler ContentChanged;
