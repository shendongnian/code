        private void GetData()
        {
            //from inside some method:
            DataSet ds = GetProgramList();
        }
        protected DataSet GetProgramList()
        {
            DataSet ds1 = new DataSet();
            using (SqlConnection cn = new SqlConnection("server=Daffodils-PC/sqlexpress;Database=Assignment1;Trusted_Connection=Yes;"))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT ProgramName FROM Program", cn))
                    da.Fill(ds1, "TableName1");
            }
            return ds1;
        }
        //
    //1. solution:
    class YourClass
    {
        DataSet ds1;
        protected void GetProgramList()
        {
            SqlConnection cn = new SqlConnection("server=Daffodils-PC/sqlexpress;Database=Assignment1;Trusted_Connection=Yes;");
            SqlCommand cmd = new SqlCommand("SELECT ProgramName FROM Program", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds1 = new DataSet();
        }
    }
