    SqlDataAdapter view_adapter = new SqlDataAdapter();
    view_adapter .SelectCommand = new SqlCommand(queryString, connection);
    view_adapter .UpdateCommand = new SqlCommand(updateCommadString, connection);
    view_adapter .DeleteCommand = new SqlCommand(deleteCommadString, connection);
    using (SqlConnection connection = new SqlConnection(connectionString))
        {
            view_adapter.Fill(dt);
            return dt;
        }
