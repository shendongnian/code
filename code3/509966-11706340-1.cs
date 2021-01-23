    public partial class _Default : Page 
    {
      protected void Page_Load(object sender, EventArgs e)
       {
       }
    [WebMethod]
    public static List<string> GetAutoCompleteData(string username)
    {
     List<string> result = new List<string>();
     using (SqlConnection con = new SqlConnection("Data Source=devserver;Initial     Catalog=Catalog;Persist Security Info=True;User ID=userName;Password=Password"))
    {
     using (SqlCommand cmd = new SqlCommand("select (strEmployeeName + ',' + strEmployeeCode) as username from tblEmployee where strEmployeeName LIKE '%'+@SearchText+'%' ", con))
    {
     con.Open();
     cmd.Parameters.AddWithValue("@SearchText", username);
     SqlDataReader dr = cmd.ExecuteReader();
     while (dr.Read())
    {
     result.Add(dr["username"].ToString());
    }
     return result;
    }
    }
    }  
    }
