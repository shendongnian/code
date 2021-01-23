         private void PrintForm_Load(object sender, EventArgs e)
        {
        ReportDocument cry = new ReportDocument();
            try
            {
            cry.Load(@"C:\Reports\CRYPT.rpt");//your report path
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=POS;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Your Stored Procedure", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.Add("@Doc_No", System.Data.SqlDbType.VarChar, 50).Value = Globlevariable.PrintDocNo;
            DataSet st = new DataSet();
            sda.Fill(st, "DATA");
            cry.SetDataSource(st);
                cry.PrintToPrinter(1,false,0,0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
