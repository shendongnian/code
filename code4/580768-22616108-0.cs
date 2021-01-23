    query = "select finalConID from discussions where desid=@did";
    com = new SqlCommand(query, con);
    com.Parameters.AddWithValue("@did", desid);
    con.Open();
    sdr = com.ExecuteReader();
    while (sdr.Read())
    {
        if (sdr.GetString(0).Equals("none") == false && !sdr.IsDBNull(0) )
        {
            finalConId = sdr.GetString(0);
            break;
        }
    }
    con.Close();
    enter code here
