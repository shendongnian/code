    private void btnclick()
    {
        DataSet ds = Session["test"] as DataSet;
        PerformFinalTransformation(ds);
        using (SqlConnection conn = new SqlConnection(my_connection_string)) {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("insert_multiple_tables", conn)) {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@table0", SqlDbType.Structured);
                param.Value = ds.Tables[0];
                cmd.Parameters.Add(param);
                SqlParameter param = new SqlParameter("@table1", SqlDbType.Structured);
                param.Value = ds.Tables[1];
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
        }
    }
