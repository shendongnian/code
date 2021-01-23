            if (rptConnection.ServerName == null || rptConnection.ServerName != DBHost)
                rptConnection.ServerName = DBHost;
            if (rptConnection.ServerName == null || rptConnection.DatabaseName != DBName)
                rptConnection.DatabaseName = DBName;
            rptConnection.UserID = DBUserID;
            rptConnection.Password = DBPassword;
            foreach (ReportDocument subRpt in rptDoc.Subreports)
            {
                foreach (Table crTable in subRpt.Database.Tables)
                {
                    crTable.LogOnInfo.ConnectionInfo.AllowCustomConnection = true;
                    TableLogOnInfo logInfo = crTable.LogOnInfo;                    
                    logInfo.ConnectionInfo = rptConnection;
                    crTable.ApplyLogOnInfo(logInfo);
                }
            }
            foreach (Table crTable in rptDoc.Database.Tables)
            {
                crTable.LogOnInfo.ConnectionInfo.AllowCustomConnection = true;
                TableLogOnInfo loi = crTable.LogOnInfo;
                loi.ConnectionInfo = rptConnection;
                crTable.ApplyLogOnInfo(loi);
            }            
        }
