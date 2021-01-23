    private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = selectallrecord();
            CrystalReport1 cr1 = new CrystalReport1();
            cr1.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cr1;
            
        }
        public DataTable selectallrecord()
        {
            Connection c = new Connection();
            //c.main();
            if (c.cn.State == ConnectionState.Open)
            {
                c.cn.Close();
                c.cn.Open();
            }
            DataSet DS = new DataSet();
            string USER = "";
            USER = "SELECT * FROM StudentInfo";
            SqlDataAdapter DA = new SqlDataAdapter(USER, c.cn);
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
