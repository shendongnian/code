        List<string> returnList;
        int index = 0;
        SqlCommand cmd = new SqlCommand("ExampleStoredProc", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        while (true)
        {
            cmd.Parameters.Add(
                new SqlParameter("@index", index));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                returnList = new List<string>();
                returnList.Add(dr.GetString(0).Trim());
                //transfer data here
            }
            else
            {
                break;
            }
            index++;
        }
