    private bool _showLabel;
    
    public bool ShowLabel
    {
        get { return _showLabel; }
        set
        {
            _showLabel = value;
            Visible = value
        }
    }
