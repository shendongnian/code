            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            connectionString = "data source=server; initial catalog=DBO;user id=sa; password= passw0rd";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "select BadgeNo as DataColumn1,Name as DataColumn2, Section as DataColumn3 from Safety where ID = '24'";
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            cnn.Close();
            DataSet1 ds = new DataSet1();
            dscmd.Fill(ds, "DataTable1");
            ReportobjRpt = new Report1 ();
            ReportobjRpt.SetDataSource(ds.Tables[0]);
            CrystalReportViewer1.ReportSource = ReportobjRpt;
            CrystalReportViewer1.RefreshReport();
        }
