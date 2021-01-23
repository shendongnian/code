    public override void XXX(Guid a, uint b, DateTime c)
    {
        string strSql = "SP_Name";
        lock (lockObject) {  // lock the code for the duration of execution so it is thread safe now (because you in singleton) 
    // But this is bad for DB access !!!! What if SP executes long - other threads have to wait
    // Use simple static methods for data access and no `lock`
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", a.ToString());
                    cmd.Parameters.AddWithValue("@b", (int)b);
                    cmd.Parameters.AddWithValue("@c", c);
                    // no need for any `try-catch` here because `using` is that and `finally`
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //....
                        }
                    }
                
                }
                conn.Close();
            }
        }
    }
