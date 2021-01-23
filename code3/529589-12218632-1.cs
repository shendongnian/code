    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.Parameters.Add(
		new SqlParameter("@NAME", name1));
    cmd.Parameters.Add(
		new SqlParameter("@EMAIL", email1));
    cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
