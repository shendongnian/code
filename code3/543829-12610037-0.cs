    sqlCommand cmd =new sqlCommand();
    SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                   //code
                                }
                             }
