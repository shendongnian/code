    [AutoComplete(true)]
    public bool DoSomething(string args)
    {
        DoSomeDBWork(args);
        try {
            DBAccess.RunQuery("INSERT fail");
            return 0;
        }
        catch (Exception ex)
        {
            DBAccess.Rollback();
            DBAccess.RunQuery("INSERT INTO Log VALUES ('{0}')", ex.ToString());
            return -1
        }
    }
