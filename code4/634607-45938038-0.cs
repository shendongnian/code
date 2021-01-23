     SqlDataAdapter sda = new SqlDataAdapter("select * from MRU1 where RegDate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "'", con);
     
     DataTable dt = new DataTable();
     sda.Fill(dt);
          
     RegisCrystalReport cos = new RegisCrystalReport();
     cos.SetDataSource(dt);
     crystalReportViewer1.ReportSource = cos;
