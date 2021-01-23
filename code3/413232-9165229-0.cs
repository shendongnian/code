    private void Load<TVar, TSet>(ref TVar var, TSet obj, TVar def)
    {
        //this is a little heavy-handed, but in pretty much any situation where 
        //this can fail, you just want the basic type.
        try
        {
           if (var is IConvertible && obj is IConvertible)
              var = (TVar)Convert.ChangeType(obj, typeof(TVar));
           else
              var = (TVar)obj; //there may just be an explicit operator
        }
        catch(Exception) 
        {
           var = def; //defined as the same type so they are always assignable
        }
    }
