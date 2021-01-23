    class DataBaseConnection
    {
        private OdbcConnection conn1 = new OdbcConnection(@"FILEDSN=C:/OTPub/Ot.dsn;" + "Uid=sa;" + "Pwd=otdata@123;"); //"DSN=Ot_DataODBC;" + "Uid=sa;" +  "Pwd=otdata@123;"
      
        //select
        public System.Data.DataTable GetData(string sql)
        {
            try
            {
                conn1.Open();
                OdbcDataAdapter adpt = new OdbcDataAdapter(sql, conn1);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                conn1.Close();
                return dt;
               
            }
            catch (Exception ex)
            {
                conn1.Close();
                throw ex;
            }
        }
    
    }
