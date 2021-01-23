    public void DoStuff()
    {
        try
        {
            _entity.SuspendNotifications();
            setProperties();
        }
            
        finally
        {
            _entity.ResumeNotifications();
        }
    }
    private setProperties()
    {
        _entity.ID = 123454;
        _entity.Name = "Name";
        _entity.Description = "Desc";
    }
