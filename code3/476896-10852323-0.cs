    public SPListItemCollection GetACollection()
    {
        try
        {
            //Method to get an item collection from somewhere
            if(itemCol != null && itemCol.Count == 0)
                return itemCol;
            return itemCol;
        }
        catch(Exception ex)
        {
            LogException(ex);
        }
    
        return null;
    }
