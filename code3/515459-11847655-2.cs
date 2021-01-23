    private int? id;
    // Now use the field in the property bodies
    public int? Id {
        get 
        { 
            return id.GetValueOrDefault(0);  
        }
        set 
        {
            if (DisplayOrder == null) DisplayOrder = DEFAULT_DISPLAY_ORDER;
            id = value;
        }
    }
