    public MyControl()
    {
        InitializeComponents();
        if (DesignerProperties.GetIsInDesignMode(this))
            return;
        _searchThread = new Thread(search);
        _searchThread.Start();
    }
