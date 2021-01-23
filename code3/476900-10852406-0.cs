    public SPListItemCollection GetACollection()
    {
        try
        {
            //Method to get an item collection from somewhere
            if(itemCol != null)
                return itemCol;
        }
        catch(Exception ex)
        {
            LogException(ex);
        }
        return null;
    }
