    public class ClassDataManagement 
    { 
       public DataTable GetData(string sqlcmdString, string connString)
       {
           SqlConnection con = new SqlConnection(connString);
           SqlCommand cmd = new SqlCommand(sqlcmdString, cn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           con.Open();
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt;
       } 
    }
