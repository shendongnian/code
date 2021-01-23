    public int? Id {
        get 
        { 
            return Id.GetValueOrDefault(0); // This will keep calling the getter of Id. You need a backing field instead.
        }
        set 
        {
            if (DisplayOrder == null) DisplayOrder = DEFAULT_DISPLAY_ORDER;
            Id = value; // And here...
        }
    }
