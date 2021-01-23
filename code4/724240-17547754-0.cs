    private int updates = 0;
    public bool Updating { get { return updates > 0; } }
    
    public void BeginUpdate()
    {
        updates++;
    }
    
    public void EndUpdate()
    {
        updates--;
    }
    public void IndividualCheckBoxChanged(...)
    {
        if (!Updating)
        {
            // run code
        }
    }
    public void CheckAllChanged(...)
    {
        BeginUpdate();
        try
        {
            // run code
        }
        finally
        {
            EndUpdate();
        }
    }
