    TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
    ConnectionInfo crConnectionInfo = new ConnectionInfo();
    Tables CrTables;
    
    crConnectionInfo.ServerName = frmMain.dbSrvrName;
    crConnectionInfo.DatabaseName = frmMain.dbName;
    crConnectionInfo.UserID = frmMain.dbUsrName;
    crConnectionInfo.Password = frmMain.dbPass;
    CrTables = cryRpt.Database.Tables;
    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
    {
    crtableLogoninfo = CrTable.LogOnInfo;
    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
    CrTable.ApplyLogOnInfo(crtableLogoninfo);
    }
