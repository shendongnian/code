    if (tmpUpdate.HasValue)
    {
       if (tmpCreate.HasValue)
       {
           lastChangedIndrole = (tmpCreate > tmpUpdate ? tmpCreate : tmpUpdate);
       }
       else
       {
           lastChangedIndrole = tmpUpdate;
       }
    }
    else
    {
       if (tmpCreate.HasValue)
       {
           lastChangedIndrole = tmpCreate;
       }
       else
       {
           lastChangedIndrole = null;
       }
    }
