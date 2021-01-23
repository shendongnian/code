    ConnectionInfo crconnectioninfo = new ConnectionInfo();
        ReportDocument cryrpt = new ReportDocument();
        TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
        TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();
        Tables CrTables;
        crconnectioninfo.ServerName = "localhost";
        crconnectioninfo.DatabaseName = "dbclients";
        crconnectioninfo.UserID = "ssssssss";
        crconnectioninfo.Password = "xxxxxxx";  
      cryrpt.Load(Application.StartupPath + "\\rpts\\" + dealerInfo.ResourceName);
            CrTables = cryrpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }
            cryrpt.RecordSelectionFormula = getCustInfoRptSelection();
            cryrpt.Refresh();
            allReportViewer.ReportSource = cryrpt;
