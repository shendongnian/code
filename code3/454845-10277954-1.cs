    try
    {
        proxy.BeginTransaction();
        proxy.AddEmployee("Stav", "20");
        proxy.AddEmployee("Stav123", "Not a Number(-->will do Exception)");
        proxy.CommitTransaction();
    }
    catch
    {
        proxy.RollBackTransaction();
    }
    finally
    {
        proxy.CloseConnection();
    }
