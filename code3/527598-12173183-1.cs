    public void UpdateQuery(int id, int newOrder)
    {
        string sql = "update Tama38News set [OrderingNumber] = @OrderingNumber where [ID] = @ID";
        using(var con = new SqlConnection(connection))
        {
            using(var command = new SqlCommand(sql, con))
            {
                con.Open();
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@OrderingNumber", newOrder);
                command.ExecuteNonQuery();
            }
        }
    }
