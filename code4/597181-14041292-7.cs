    try
    {
        SqlDataReader dr = cmd1.ExecuteReader();
    }
    catch (SqlException oError)
    {
    
    }
    while(dr.Read())
    {
        string treatment = dr[0].ToString();
    }
