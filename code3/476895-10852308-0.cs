    public SPListItemCollection GetACollection()
    {
        try
        {
            //Method to get an item collection from somewhere
            if(itemCol.Any())
                return itemCol;
        }
        catch(Exception ex)
        {
            LogException(ex);
        }
    
        return null;
    }
