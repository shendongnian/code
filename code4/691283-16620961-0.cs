       public void GroupwiseRegistrationReport()
            {
                SqlConnection connection;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                connection = gen.con;
                string SP = "";
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction = null;            
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    if (rblReportFrom.SelectedValue == "0")
                    {
                        SP = "SPGroupwiseIndustriesEM1Report";
                    }
                    else
                    {
                        SP = "SPGroupwiseIndustriesEM2Report";
                    }
                ds = gen.FunSearch_Trans(ParameterData, ValueData, SP, transaction, command);
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                    {          
                        ReportDocument doc;
                        doc = new ReportDocument();
    
                if (rblReportFrom.SelectedValue == "0")
                {
                    doc.Load(Server.MapPath("~\admin\Reports\Groupwise-EM-II-Registration-Report.rpt"));
                }
                else
                {
                    doc.Load(Server.MapPath("~~\admin\Reports\Groupwise-EM-II-Registration-Report.rpt"));
                }
                doc.SetDataSource(ds.Tables[0]);
    
                configureCrystalReports();
                          
                doc.SetParameterValue("@fromdate", ValueofFromDate);
                doc.SetParameterValue("@Todate", ValueoftoDate);
                
                crvMSMEReportViewer.ReportSource = doc;
                crvMSMEReportViewer.RefreshReport();
                        }
                        
                    }
                }
