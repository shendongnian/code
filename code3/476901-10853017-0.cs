    public SPListItemCollection GetACollection()
    {
       SPListItemCollection itemCol = null;
       try
       {
          itemCol = //Method to get an item collection from somewhere
       }
       catch(Exception e)
       {
          LogException(e);
       }
       return itemCol;
    }
