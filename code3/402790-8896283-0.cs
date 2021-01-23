        this.ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEvent);
        void SubreportProcessingEvent(object sender, SubreportProcessingEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            ds = getSubReportData(e.Parameters[0].Values[0]);
            ReportDataSource rds = new ReportDataSource("SqlDataSourceProg", ds.Tables["SiteProfileSvcRate"]);
            rds.Name = "SiteProfileSvcRate";
            
            e.DataSources.Add(rds);
        }
        private DataSet getSubReportData(string strSvcId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sParam = new SqlParameter[1];
            sParam[0] = new SqlParameter("svcid", strSvcId);
            ds = dac.GetDataSet("xwiWR_SP_SiteProfile_SvcRate_Current", sParam, "SiteProfileSvcRate");
            return ds;
        }
