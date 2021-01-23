    if (args.Count != 0) {
        using (SqlConnection con = new SqlConnection(CONNSTR)) {
            con.Open();
            SqlTransaction tran = con.BeginTransaction(IsolationLevel.ReadUncommitted);
            try {
                using (SqlCommand cmd = new SqlCommand(cmdText, con, tran)) {
                   for (var i = 0 ; i != args.Count ; i++) {
                       cmd.Parameters.AddWithValue("@id"+i, args[i].Item1);
                       cmd.Parameters.AddWithValue("@old"+i, args[i].Item2);
                       cmd.Parameters.AddWithValue("@new"+i, args[i].Item3);
                   }
                   cmd.ExecuteNonQuery(); // updated records
                }
                tran.Commit();
            } catch (SqlException ex) {
                tran.Rollback();
            }
            con.Close();
        }
    }
