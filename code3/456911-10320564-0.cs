    public MyUserControl()
    {
        InitializeComponent(); 
    }
    public AdjustControlSize(bool open)
    {
        _openHeight = this.Height;
        _closedHeight = splitContainer1.SplitterDistance;
        Open = open; 
    }
    //the rest of the control's code is unchanged
    ...
