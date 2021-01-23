    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
    sb.DataSource = Properties.Settings.Default.DBServerName;
    sb.InitialCatalog = Properties.Settings.Default.DBDatabaseName;
    sb.IntegratedSecurity = Properties.Settings.Default.DBUseIntegratedSecurity;
    if (!sb.IntegratedSecurity)
    {
        sb.UserId = Properties.Settings.Default.DBUserName;
        sb.Password = Properties.Settings.Default.DBPassword;
    }
    using (SqlConnection conn = new SqlConnect(sb.ConnectionString))
    {
        ...
    }
