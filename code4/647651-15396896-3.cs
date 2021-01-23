    using(SqlConnection cn = new SqlConnection(.........))
    {
        cn.Open();
        SqlCommand Command = new SqlCommand("InsertOrUpdateSlotFromCode", cn);
        Command.CommandType = CommandType.StoredProcedure;
        Command.Parameters.AddWithValue("date", date);
        Command.Parameters.AddWithValue("room", rooms_combo.SelectedValue);
        Command.ExecuteNonQuery();
    }
