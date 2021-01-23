        public static void SetReportLogOnInfo(ReportDocument report)
        {
            if (!report.IsLoaded)
                report.Refresh(); //workaround for report.FileName empty error
            foreach (CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo oldInfo in report.ReportClientDocument.DatabaseController.GetConnectionInfos())
            {
                var newInfo = oldInfo.Clone(true);
                newInfo.UserName = [ConnectionString.UserID];
                newInfo.Password = [ConnectionString.Password];
                newInfo.Attributes["QE_LogonProperties"]["Server"] = [ConnectionString.DataSource];
                report.ReportClientDocument.DatabaseController.ReplaceConnection(oldInfo, newInfo, null, CrDBOptionsEnum.crDBOptionDoNotVerifyDB);
            }
        }
