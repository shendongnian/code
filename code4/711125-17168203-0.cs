    SqlConnection conn = new SqlConnection(@"Server(local);Database=Sample_db;Trusted_Connection=Yes;");
    conn.Open();
    
    string sql= "SELECT * FROM emp";     
    
    SqlCommand cmd = new SqlCommand(sql); 
    cmd.Connection = conn;
                 
    SqlDataAdapter sda = new SqlDataAdapter(cmd);               
    DataTable dt = new DataTable("emp");
    sda.Fill(dt);
