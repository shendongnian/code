    using (SqlCommand comm = conn.CreateCommand()) //release good practice
    {
        comm.CommandText = "delete FROM tbl_user where user_id = @user_id";
        comm.CommandType = CommandType.Text; //can be skipped for your case
        comm.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int)).Value =
            parameterValue;
        comm.ExecuteNonQuery();
    }
