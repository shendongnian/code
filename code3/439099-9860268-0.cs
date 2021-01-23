    try
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataReader rdr = null;
        SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con);
        rdr = cmd.ExecuteReader();
    }
    catch(Exception)
    {
        throw;
    }
