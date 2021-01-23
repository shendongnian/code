    static void Main(string[] args) {
        string connectionString = "Data Source=H....; 
        Initial Catalog=LANDesk; Persist Security Info=True; 
        User ID=Mainstc; Password=xxxxxxxx";
        using(SqlConnection con = new SqlConnection(connectionString))
        {
          con.Open();
        }
    }
