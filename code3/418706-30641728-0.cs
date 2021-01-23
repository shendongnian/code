    try
    {
        if (AnyConditionTrue)
        {
            MethodWhenTrue();
        }
        else
        {
            HandleError(new Exception("AnyCondition is not true"));
        }
    }
    catch (Exception ex)
    {
        HandleError(ex);
    }
...                   
                                
    private void HandleError(Exception ex) {
        throw new ApplicationException("Failure!", ex);
    }
