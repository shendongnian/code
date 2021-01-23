    foreach (ReportDocument subReport in report.Subreports)
    {
        SetDatabaseConnectionInformation(subReport);
    }
    private void SetDatabaseConnectionInformation(ReportDocument report)
    {
        ConnectionInfo connectionInfo = new ConnectionInfo();
        connectionInfo.AllowCustomConnection = true;
        connectionInfo.Type = ConnectionInfoType.SQL;
        connectionInfo.ServerName = MyServer;
        connectionInfo.IntegratedSecurity = (true or false);
        connectionInfo.UserID = MyUserName;
        connectionInfo.Password = MyPassword;
        foreach (Table table in report.Database.Tables)
        {
            TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
            tableLogOnInfo.ConnectionInfo = connectionInfo;
            table.ApplyLogOnInfo(tableLogOnInfo);
        }
    }
