    protected virtual bool CollapseVersions
    {
        get
        {
            SwitchParameter allVersions = this.AllVersions;
            if (allVersions.IsPresent)
            {
                return false;
            }
            else
            {
                return this.ListAvailable;
            }
        }
    }
