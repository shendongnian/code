    Check that your load method is getting the full path of the report,if not then use
    rd.Load(Server.MapPath("CrystalReport2.rpt")) and change your programming like i
    mentioned.
    private void Form10_Load(object sender, EventArgs e)
            {
                String connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\bank.mdf;Integrated Security=True;User Instance=True";
                SqlConnection conn = new SqlConnection(connString);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from my_table", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ReportDocument rd = new ReportDocument();
                rd.Load("CrystalReport2.rpt");
                rd.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rd;
                rd.Refresh();
                this.crystalReportViewer1.ReportSource = rd;
            }
    I think it will help for you.
