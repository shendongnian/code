        var interceptor = new SchemaSqlInterceptor();
        using (var session = sessionFactory.OpenSession(interceptor))
        {
            interceptor.MASTER_USER = "test$master";
            interceptor.TRAN_USER = "test$tran";
            var query = session.GetNamedQuery("GetAllClients");
            var clients = query.List<Models.Client>();
            session.Close();
        }
