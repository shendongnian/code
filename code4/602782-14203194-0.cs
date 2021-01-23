    public property MySanitizedItemsList
    {
        get
        {
            if (Items.Length == 1 && Items[0] == null)
                return null
            else
                return Items;
        }
    }
