    rpt.Load(reportPath);
    ConnectionInfo connectionInfo = new ConnectionInfo();
    connectionInfo.DatabaseName = "Northwind";
    connectionInfo.UserID = "user";
    connectionInfo.Password="user123";
    ConnectionInfo altConnectionInfo = new ConnectionInfo(); 
    connectionInfo.DatabaseName = "altDataBase";
    connectionInfo.UserID = "atlUser";
    connectionInfo.Password="123user123";
    SetDBLogonForReport(connectionInfo, altConnectionInfo, rpt);
    CrystalReportViewer1.ReportSource = rpt;
    
     private void SetDBLogonForReport(ConnectionInfo connectionInfo, ConnectionInfo altConnectionInfo ReportDocument reportDocument)
    {
        Tables tables = reportDocument.Database.Tables;
        foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
        {
            TableLogOnInfo tableLogonInfo = table.LogOnInfo;
            //you can add as much tables as you want but associated with the same connectionInfo
            if (table.Name == "SomeTable") { tableLogonInfo.ConnectionInfo = altConnectionInfo; }
            //if you have multiple connections, you could even use switch structure depending on the table name.
            else { tableLogonInfo.ConnectionInfo = connectionInfo; }
            //unfortunately, this uses table name property, so you must specify any table name depending on the connection you want to associate with.  
            table.ApplyLogOnInfo(tableLogonInfo);
        }
    }
