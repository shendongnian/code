    SqlCommand cmd1 = new SqlCommand("INSERT INTO Userinformation(Access)
                                       VALUES('"+nameAccess.Text+"')",con);
    SqlDataReader dr = cmd1.ExecuteReader();
    if (dr.Read())
    {
       MessageBox.Show("User Access Blocked");
    }
    dr.Close();
