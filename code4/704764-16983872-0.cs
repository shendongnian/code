    using (SqlConnection c = new SqlConnection("your connection string"))
    {
        c.Open();
        using (SqlCommand cmd = new SqlCommand("select date from customer where ID = @ID", c))
        {
            cmd.Parameters.AddWithValue("@ID", Id);
            var val = cmd.ExecuteScalar();
            Calendar1.SelectedDate = Convert.ToDateTime(val);
        }
    }
