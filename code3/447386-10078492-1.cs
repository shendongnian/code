        string sqlQuery = "UPDATE TableName SET Total=@Total WHERE ID=@ID";
        using (SqlConnection dataConnection = new SqlConnection(conn))
        {
            using (SqlCommand dataCommand = new SqlCommand(sqlQuery, dataConnection))
            {
                var total = (int)e.NewValues["Total"] + 1;
                dataCommand.Parameters.AddWithValue("Total", total);
                dataCommand.Parameters.AddWithValue("ID", (int)e.Keys["ID"].Value);
                dataConnection.Open();
                dataCommand.ExecuteNonQuery();
            }
        }
