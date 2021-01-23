    public class ClassDataManagement 
    { 
       public DataTable GetData(string SQL)
        {
              string YourConnectionString = ConfigurationManager.ConnectionStrings["_uniManagementConnectionString1"].ConnectionString;                  
              using(SqlConnection cn = new SqlConnection(YourConnectionString))
              {
                  SqlCommand cmd = new SqlCommand(SQL, cn);
                  SqlDataAdapter da = new SqlDataAdapter(cmd);
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  if(cmd != null)((IDisposable)cmd).Dispose();
                  if(da != null)((IDisposable)da).Dispose(); 
              }
              return dt;
        } 
    }
