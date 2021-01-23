    void SetConnection(ReportDocument rd, crConnectionInfo ci)
    {
    
        foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in rd.Database.Tables)
        {
            TableLogOnInfo logon = tbl.LogOnInfo;
            logon.ConnectionInfo = ci;
            tbl.ApplyLogOnInfo(logon);
            tbl.Location = tbl.Location;
        }
        if (!rd.IsSubReport) {
            foreach {ReportDocument sd in rd.SubReports) {
                SetConnection(sd,ci)
            }
        }
    }
