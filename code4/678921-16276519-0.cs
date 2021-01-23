    static string connectionString = "Server=.\\SQLExpress;AttachDbFilename=L:\\Apps\\VS Projects\\Carnisoftix\\CarniDb.mdf;Database=CarniDb;Trusted_Connection=Yes;";
    
    public static void regUsr(carniuser oUsr)
    {
        using(SqlConnection oConnection = new SqlConnection(connectionString))
        {
            oConnection.Open();
    
            using (SqlCommand oCom = new SqlCommand("ADDUSR", oConnection))
            {
                oCom.CommandType = CommandType.StoredProcedure;
                oCom.Parameters.AddWithValue("@useremail", oUsr.Email);
                oCom.Parameters.AddWithValue("@userpass", oUsr.Pass);
                oCom.Parameters.AddWithValue("@name", oUsr.Name);
                oCom.Parameters.AddWithValue("@phone", oUsr.Phone);
                oCom.Parameters.AddWithValue("@address", oUsr.Address);
                oCom.Parameters.AddWithValue("@username", oUsr.Usrname);
                oCom.Parameters.AddWithValue("@authority", oUsr.Auth);
                oCom.Parameters.AddWithValue("@special", oUsr.SpecialK);
                oCom.ExecuteNonQuery();
            }
            
            oConnection.Close();
        }
    }
