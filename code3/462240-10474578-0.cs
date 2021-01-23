    private void button1_Click(object sender, EventArgs e)
            {
                CrystalReport1 rpt = new CrystalReport1();
                SqlConnection cn = new SqlConnection("data source=localhost;initial catalog=acc;uid=sa;pwd=fantastic;");
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cmd.CommandText = "select EmpNo, EName from Emp";
                da.SelectCommand = cmd;
                dt.Clear();
                da.Fill(dt);
                rpt.SetDataSource(dt);
                rpt.PrintToPrinter(1, false, 0, 0);
            }
