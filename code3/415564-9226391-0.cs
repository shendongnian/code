    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
    csb.DataSource = <your server instance, e.g. "localhost\sqlexpress">;
    csb.InitialCatalog = <name of your database>;
    csb.IntegratedSecurity = <true if you use integrated security, false otherwise>;
    if (!csb.IntegratedSecurity)
    {
        csb.UserId = <User name>;
        csb.Password = <Password>;
    }
