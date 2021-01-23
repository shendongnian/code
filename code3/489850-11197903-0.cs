    ReportDocument currentReport = new ReportDocument();  
    currentReport.Load([path to .rept], OpenReportMethod.OpenReportByTempCopy);
    ConnectionInfo crConnectionInfo = new ConnectionInfo();
    //Set your connection params here  
    for (int i = 0; i < currentReport.Database.Tables.Count; i++)
    {
        Table crTable = currentReport.Database.Tables[i];
        crTableLogOnInfo = crTable.LogOnInfo;
        crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
        crTable.ApplyLogOnInfo(crTableLogOnInfo);
    }
    foreach(IConnectionInfo cn in currentReport.DataSourceConnections)
    {
        cn.SetConnection(_server, _database, _windowsAuth);        
        cn.SetLogon(_userName, _password);
    }  
