    using (SqlCommand cmd = new SqlCommand())
    {
        using (SqlConnection cn = new SqlConnection(s.ConnectionString.ConnectionString))
        {
            cmd.Connection = cn;
            cmd.CommandText = "asp_FinalInspectionTransaction";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlTransaction trans = cn.BeginTransaction();
            cmd.Transaction = trans;
            cn.Open();
            try
            {
                for (int i = 0; i < array1.Length - 1; i++)
                {
                    cmd.Parameters.AddWithValue("@MasterID", masterID);
                    cmd.Parameters.AddWithValue("@TagName", array1[i]);
                    cmd.Parameters.AddWithValue("@TagValue", array2[i]);
                    cmd.ExecuteNonQuery();
                    // cmd.Parameters = new SqlParameterCollection(); <-- This is a read only collection created when constructing the command
                }
                trans.Commit();
            }
            catch (Exception e) // As you are doing the same thing on boths exceptions one handler is enought
            {
                using (LogManager lm = new LogManager())
                {
                    lm.WriteErrorTextLog(e, "Broken Manager - Final Inspection Broker");
                }
                trans.Rollback();
            }
        }
    }
