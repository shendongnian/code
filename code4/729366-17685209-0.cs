    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    builder.DataSource = @"(local)\SQLExpress";
    builder.UserInstance = true;
    builder.IntegratedSecurity = true;
    builder.AttachDBFilename = "|DataDirectory|ConfigurationData.mdf";
    SqlConnection conn = new SqlConnection(builder.ConnectionString());
