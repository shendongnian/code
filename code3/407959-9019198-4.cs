    private int statusId;
    public Types.StatusTypes Status 
    { 
        get 
        {
            return (Types.StatusTypes)statusId;
        }
        set
        {
            statusId = (int)value;
        }
    }
    public Int StatusId 
    { 
        get 
        {
            return statusId;
        }
    }
    
