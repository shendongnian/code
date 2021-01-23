    ReportDocument rpt = new ReportDocument();
            rpt.Load(@"C:\CrystalReport1.rpt");
           
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = "SERVERNAME";
            crConnectionInfo.DatabaseName = "DATABASENAME";
            crConnectionInfo.UserID = "USERNAME";
            crConnectionInfo.Password = "PASSWORD";
            crConnectionInfo.IntegratedSecurity = false;
            TableLogOnInfos crTableLogonInfos = new TableLogOnInfos();
            TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();
            Tables CrTables;
            CrTables = rpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in CrTables)
            {
                crTableLogonInfo = crTable.LogOnInfo;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogonInfo);
            }
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
