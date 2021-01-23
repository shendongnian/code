    public bool busy
    {
        get
        {
             return _isUserLoading || _isOtherDataLoading;
        }
    }
