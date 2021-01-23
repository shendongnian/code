    public void InsertProjekt(string Projektbezeichnung)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Server=localhost; Database=myProjekt; UID=user; PWD=pwd";
        con.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "Insert into tblProjekte (Projektbezeichnung) values (@value)"
        com.Parameters.AddWithValue("@value", Projektbezeichnung);
        
        int rows = com.ExecuteNonQuery();
