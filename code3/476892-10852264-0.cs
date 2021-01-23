    public SPListItemCollection GetACollection()
    {
        try
        {
            //Method to get an item collection from somewhere
            if(itemCol != null)
                return itemCol;
   
            //Some if/else code here presumably... 
   
            //NO ELSE HERE...
            return null;
        }
        catch(Exception ex)
        {
            LogException(ex);
            return null;
        }
    }
