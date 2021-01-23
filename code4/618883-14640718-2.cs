    private void SetDBLogonForReport(ConnectionInfo conInfo, ReportDocument report)
        {
            Tables tables = report.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = conInfo;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
        }
