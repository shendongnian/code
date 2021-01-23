    public class DataAccess : IDataAccess  
    {
        public static string CONNSTR = ConfigurationManager.ConnectionStrings["SqlDbConnect"].ConnectionString;
    
        public DataAccess()
    
        {
    
        }
    
      object GetScalar(string sql)
      {
          return new object();
      }
      int InsOrUpdOrDel(string sql)
      {
          return 1;
      }
      public System.Data.DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
