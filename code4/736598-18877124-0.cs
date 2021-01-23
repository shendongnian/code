        public void LoadCrystalReportViewer(CrystalReportViewer crystalReportViewer, CrystalReportSource crystalReportSource, string reportFilePath, Dictionary<string, object> parameters)
        {
            crystalReportSource.ReportDocument.FileName = reportFilePath;
            crystalReportSource.ReportDocument.Load(reportFilePath);
            crystalReportSource.ReportDocument.Database.Tables[0].LogOnInfo.ConnectionInfo.Password = "PASSWORD";
            crystalReportSource.ReportDocument.Database.Tables[0].ApplyLogOnInfo(crystalReportSource.ReportDocument.Database.Tables[0].LogOnInfo);
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                if (crystalReportSource.ReportDocument.ParameterFields[parameter.Key] != null)
                {
                    crystalReportSource.ReportDocument.SetParameterValue(parameter.Key, parameter.Value);
                }
            }
            crystalReportSource.EnableCaching = true;
            crystalReportSource.CacheDuration = 300;
            crystalReportViewer.ReportSource = crystalReportSource;
            crystalReportViewer.ReuseParameterValuesOnRefresh = true;
            crystalReportViewer.EnableParameterPrompt = false;
            crystalReportViewer.LogOnInfo.Add(crystalReportSource.ReportDocument.Database.Tables[0].LogOnInfo);
            foreach (ParameterField parameterField in crystalReportViewer.ParameterFieldInfo)
            {
                parameterField.DefaultValues = crystalReportSource.ReportDocument.ParameterFields[parameterField.Name].CurrentValues;
            }
            crystalReportViewer.Visible = true;
        }
