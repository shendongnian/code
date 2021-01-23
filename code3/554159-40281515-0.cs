    try
    {
        ...
        transaction.Commit();
    }
    catch (Exception ex)
    {
        try
        {
            ...
            transaction.Rollback();
        }
        catch (Exception ex2)
        {
            ...
        }
    }
