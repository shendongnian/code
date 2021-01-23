    DataTable dataTable = GetData();
    // Configure the SqlCommand and SqlParameter.
    SqlCommand cmd= new SqlCommand(
        "GetIDs", connection);
    cmd.CommandType = CommandType.StoredProcedure;
    SqlParameter tvpParam = cmd.Parameters.AddWithValue(
        "@TableVariable", dataTable);
    tvpParam.SqlDbType = SqlDbType.Structured;
