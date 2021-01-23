    public static void WitreToDatabase(byte[] tabTempTest, int i)
    {
        //First method to execute SQL procedure
        string queryStmt = "INSERT INTO dbo.DOCUMENT(DOC_CONTENU, DOC_LENGTH) VALUES(@CONTENU, @LENGTH)"; //Store length it's to easy for future
        using (SqlConnection _con = new SqlConnection("Data Source=SERVER_NAME;Initial Catalog=THOMAS;User ID=id;Password=pass"))
        using (SqlCommand _cmd = new SqlCommand(queryStmt, _con))
        {
            SqlParameter param = _cmd.Parameters.Add("@CONTENU", SqlDbType.VarBinary);
            SqlParameter param2 = _cmd.Parameters.Add("@LENGTH", SqlDbType.Int);
            param.Value = tabTempTest;
            param2.Value = i;
    
            _con.Open();
            _cmd.ExecuteNonQuery();
            _con.Close();
        }
    }
