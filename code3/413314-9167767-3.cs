    public class ClassDataManagement 
    { 
       public DataTable GetData(string SQL)
        {
              string YourConnectionString = ConfigurationManager.ConnectionStrings["_uniManagementConnectionString1"].ConnectionString;                  
              using (SqlConnection cn = new SqlConnection(YourConnectionString))
              using (SqlCommand cmd = new SqlCommand(SQL, cn))
              using (SqlDataAdapter da = new SqlDataAdapter(cmd))
              {
                  DataTable dt = new DataTable();
                  da.Fill(dt);
              }
              return dt;
        } 
    }
