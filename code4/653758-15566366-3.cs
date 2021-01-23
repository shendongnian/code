    static void Main(string[] args) {
        string connectionString = "Data Source=H....; 
        Initial Catalog=LANDesk;User ID=Mainstc; Password=xxxxxxxx"; 
        // removed Persist Security Info=True; 
        using(SqlConnection con = new SqlConnection(connectionString))
        {
          con.Open();
        }
    }
