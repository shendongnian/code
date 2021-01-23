        ...
        try
        {
            conn.Open();
            //SqlTransaction trans = conn.BeginTransaction();
            //comm.Transaction = trans;
            comm.Parameters.Add("@first", SqlDbType.Text);
            comm.Parameters.Add("@last", SqlDbType.Text);
            comm.Parameters.Add("@addy", SqlDbType.Text);
            comm.Parameters.Add("@city1", SqlDbType.Text);
            comm.Parameters.Add("@stat", SqlDbType.Text);
            comm.Parameters.Add("@zippy", SqlDbType.SmallInt);
            // This is what you forgot:
            comm.ExecuteNonQuery();
        }
        ...
