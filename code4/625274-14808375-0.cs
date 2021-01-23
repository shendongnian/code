    query = "select dg.start_rcv_datetime from ...";
    using (OracleCommand cmd = new OracleCommand(query, conn))
    {
        using (OracleDataReader dr = cmd.ExecuteReader())
        {
            int dateColumn = dr.GetOrdinal("start_rcv_datetime");
            while (dr.Read())
            {
                DateTime date = dr.GetDateTime(0);
                // Or whatever - consider cultural implications
                string text = date.ToString("dd/MM/yyyy");
                InfoList.Add(text);
            }
        }
    }
