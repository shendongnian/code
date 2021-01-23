    public class bindingmethod 
    { 
        public void show(GridView gridView) 
        { 
            using(SqlConnection con = new SqlConnection(getconnectionstring()))
            using(SqlCommand cmd = new SqlCommand())
            {
                using(DataTable dt = new DataTable())
                {
                  cmd.Connection = con; 
                  con.Open(); 
            
                  using(SqlDataAdapter adb = new SqlDataAdapter("show_answers", con))
                  {
                      adb.Fill(dt); 
     
                      gridView.DataSource = dt; 
     
                      gridView.DataBind(); 
                  }
               }
            }
        } 
        //Get a connection string to make a db connection 
        public static string getconnectionstring() 
        { 
            return System.Configuration.ConfigurationManager.ConnectionStrings["crudconnection1"].ConnectionString; 
        } 
    } 
