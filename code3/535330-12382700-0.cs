    SqlConnection con = new SqlConnection('connection string here');    
    string command = "INSERT INTO Test(Id, Name) VALUES(5, 'kk')";
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = con;
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.CommandText = command;
    con.Open();
    cmd.ExecuteNonQuery();
    con.Close();
