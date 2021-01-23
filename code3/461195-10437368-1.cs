    ...
    DataTable dt = new DataTable();
    dt.Load(dr);
    dt.Columns["TotalPayment"].DataFormatString = "C";
    dt.Columns["MonthlyInstallment"].DataFormatString = "C";
    dt.Columns["TotalCommission"].DataFormatString = "C";
    dataGridView1.DataSource = dt;
