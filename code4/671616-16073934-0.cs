    using (SqlCeConnection con = new SqlCeConnection(strConn))
    {
        con.Open();
        using (SqlCeCommand cmd = new SqlCeCommand("insert into tblTest(ID, Name) values (@Val1, @val2)", con))
        {
            cmd.Parameters.AddWithValue("@Val1", idVal);
            cmd.Parameters.AddWithValue("@Val2", nameVal);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
