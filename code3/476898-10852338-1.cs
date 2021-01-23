    try
    {
         // whatever
         if(itemCol.Count == 0) itemCol = null;
    }
    catch(Exception x)
    {
         LogException(x);
         itemCol = null;
    }
    return itemCol;
