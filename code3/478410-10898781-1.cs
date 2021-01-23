        ...
        try
        {
            conn.Open();
            //SqlTransaction trans = conn.BeginTransaction();
            //comm.Transaction = trans;
            comm.Parameters.Add(firstparam);
            comm.Parameters.Add(lastparam);
            comm.Parameters.Add(addressparam);
            comm.Parameters.Add(cityparam);
            comm.Parameters.Add(stateparam);
            comm.Parameters.Add(zipparam);
            // This is what you forgot:
            comm.ExecuteNonQuery();
        }
        ...
