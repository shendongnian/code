    public bool IsOnline
            {
                get
                {
                    return isOnline;
                }
                set
                {
                    // When ONLINE tab click, check whether application is online,
                    // if not, do not display ONLINE tab
                    if (value && !applicationData.IsApplicationOnline())
                    {
                        isOnline = false;
                        return;
                    }
                    else
                    {
                        isOnline = value;
                    }
    
                    LoadTabContent();
    
                    NotifyPropertyChange("IsOnline");
                }
            }
