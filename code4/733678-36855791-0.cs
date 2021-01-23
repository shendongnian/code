    TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;
                SalesManVisit cryRpt = new SalesManVisit();
           
                crConnectionInfo.ServerName = @"TLPL_ICT_OPR\xxxxxxxxx";
                crConnectionInfo.DatabaseName = "xxxxxxx";
                
                crConnectionInfo.UserID = "xxxxx";
                crConnectionInfo.Password = "xxxxxx";
    
    
    
                CrTables = cryRpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }
                CrystalReportViewer1.ReportSource = cryRpt;
                CrystalReportViewer1.RefreshReport();
                cryRpt.Refresh();
