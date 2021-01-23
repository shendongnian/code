        using (OleDbConnection connection = new OleDbConnection(yourConnectionString))
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [CR$] where ([Req Start Date] >= ?", connection);
            adapter.SelectCommand.Parameters.Add("@p1", OleDbType.DateTime).Value = time;
          
            try
            {
                connection.Open();
                adapter.Fill(DtSet);
            }
            catch (Exception ex)
            {
                //handle error
            }
        }
