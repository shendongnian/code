    public bool CanRun
    {
        get
        {
            if(DesignMode)
                return false;
            // your database stuff
        }
    }
