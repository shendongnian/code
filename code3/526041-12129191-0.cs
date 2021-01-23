        Datatable datatable = new datatable ();
        Datatable.columns.add (“IDS”,typeof(int64));
        Foreach (int64 id in IDS)
        {
            Datatable.Rows.Add(id);
        }
     // Configure the SqlCommand and table-valued parameter.
     SqlCommand insertCommand = new SqlCommand("TVP_PROC", connection);
     insertCommand.CommandType = CommandType.StoredProcedure;
     //pass here your datatable
     SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@ID", datatable);
     
     //specify type of your parameter
     tvpParam.SqlDbType = SqlDbType.Structured;
     
      // Execute the command.
      insertCommand.ExecuteNonQuery();
