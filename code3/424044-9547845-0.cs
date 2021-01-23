    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds;
         protected void Page_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            
    
            SqlDataAdapter da = new SqlDataAdapter("select Table1.Col1,Table2.Col2,Table3.Col3 From Table1,Table2,Table3 where Table1.id=Table2.id and Table2.id=Table3.id", con);
            da.Fill(ds);
            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
    
            myReportdocument.Load(@"MyPathToReportFile.rpt");
    
                   
         myReportdocument.Database.Tables[0].SetDataSource(ds);
                  
    
         CrystalReportViewer1.ReportSource = myReportDocument;
         CrystalReportViewer1.DataBind();
    
    
    
           }
