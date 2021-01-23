    TransactionScope ts;
    try
    {
        ts = new TransactionScope(TransactionScopeOption.RequiresNew);
        try
        {
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            obj.UpdateData();
            ServiceReference2.Service1Client obj1 = new ServiceReference2.Service1Client();
            obj1.UpdateData();
            ts.Complete();
        }
        catch (Exception ex)
        {
            ts.Dispose();
        }
    }
    finally
    {
        ts.Dispose();
    }
