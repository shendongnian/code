    using (SqlDataAdapter sqlDA = new SqlDataAdapter("up_Select_all", sqlConnect))
    {
        sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDA.SelectCommand.Parameters.Add("@ID", SqlDbType.BigInt).Value = pCustomer.CustomerID;
        sqlDA.Fill(dtBets);
        return dtBets;
    }    
