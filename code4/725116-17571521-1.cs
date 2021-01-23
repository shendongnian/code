    protected void Page_Load(object sender, EventArgs e)
            {
                SqlConnection cnn;
                string connectionString = null;
                string sql = null;
                connectionString = "data source=server; initial catalog=DBO;user id=sa; password= passw0rd";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlCommand com = new SqlCommand("select BadgeNo as DataColumn1,Name as DataColumn2, Section as DataColumn3 from Safety where ID = '24'", conn);
                adap.SelectCommand = com;
                adap.Fill(tables);
                ReportDocument doc;                
                myreport.SetDataSource(tables);
                doc = new ReportDocument();
                doc.Load(Server.MapPath("RptName.rpt"));
                myreport.ReportSource = doc;
                myreport.ReportSource = myreport;
            }
