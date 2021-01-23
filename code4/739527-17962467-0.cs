    try
    {
    ...
    }
    catch (FaultException ex)
    {
       switch(ex.Code)
       {
           case 0:
              break;
           ...
       }
    }
