    public void OpenMySessionFactory(string conStr)
    {
        _sessionMutex.WaitOne();
        try
        {
            config = Fluently.Configure()
            .Database(MySQLConfiguration.Standard.ConnectionString(conStr))
            .Mappings(m => m.FluentMappings.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()))
            .BuildConfiguration();
            sessionFactory = config.BuildSessionFactory();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            _sessionMutex.ReleaseMutex();
        }
    }
