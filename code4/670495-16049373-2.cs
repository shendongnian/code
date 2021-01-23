    SqlCommand cmd = new SqlCommand("Select Users, Pass from logintable where Users= @Users  AND Pass=@Pass", conn);
    cmd.Parameters.Add("@Users", SqlDbType.VarChar, 20);
    cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 20);
    cmd.Parameters["@Users"].Value = login;
    cmd.Parameters["@Pass"].Value = pass;
    conn.Open();
    SqlDataReader reader = cmd.ExecuteReader();
    if (reader.Read()) 
    {
       new Login().show();
    }
    else
    {
       lblFail.Text = "Invalid username and password";
    }
    reader.Close();
    reader.Dispose();
    conn.Close();
    conn.Dispose();
