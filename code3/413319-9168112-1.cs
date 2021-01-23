     public class ConnectionClass
     {
     static SqlConnection cn;
       public static SqlConnection Connection()
        {
           string myConnection = ConfigurationManager.ConnectionStrings["_uniManagementConnectionString1"].ConnectionString;
          if (cn != null)
           {
            cn = new SqlConnection(myConnection);
           // cn.Open();
           }
           return cn;
          }
       }    
    public class ClassDataManagement 
    {       
     public DataTable GetData(string SQL)
       {
        using (SqlConnection cn = ConnectionClass.Connection())
         {
         //SqlCommand cmd = new SqlCommand(SQL, cn);
         SqlDataAdapter da = new SqlDataAdapter(SQL,cn);
         DataTable dt = new DataTable();
         da.Fill(dt);
         return dt;
         }
       } 
    ......
