    using (SqlCeConnection con = new SqlCeConnection(strConn))
    {
    con.Open();
    using (SqlCeCommand cmd = new SqlCeCommand("DELETE from CustTable where col1 = @Val1", con))
    {
        cmd.Parameters.AddWithValue("@Val1", customer.ID);
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.ExecuteNonQuery();
    }
    }
