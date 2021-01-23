    string ConnectionString = "PUT YOU CONNECTION STRING HERE";
    con = new SqlConnection(ConnectionString);
    con.Open();
    string CommandText = "SELECT * FROM Student WHERE GPA > 2";
    cmd = new SqlCommand(CommandText);
    cmd.Connection = con;
    rdr = cmd.ExecuteReader();
    lbx.Items.Clear();
    while (rdr.Read())
    {    
         lbx.Items.Add......
    }
