    public SPListItemCollection GetACollection()
    {
        try
        {
            //Method to get an item collection from somewhere
            return itemCol != null && itemCol.Count == 0 ? null : itemCol;
        }
        catch(Exception ex)
        {
            LogException(ex);
            return null;
        }
    }
