    private TextBox _txtValue;
    
    public EMRow()
    {
        if (_txtValue == null)
            _txtValue = new TextBox();
    }
    
    public string Value
    {
        get
        {
            return _txtValue.Text;
        }
        set
        {
            _txtValue.Text = value;
        }
    }
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public TextBox ValueTextBox
    {
        get
        {
            return _txtValue;
        }
        set
        {
            _txtValue = value;
        }
    }    
