    using (SqlConnection c = new SqlConnection("your connection string"))
    {
        c.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT IndoorTemp FROM ThermData WHERE HouseNo = @HouseNo AND Date = @Date AND Time = @Time")
        {
            cmd.Parameters.AddWithValue("@HouseNo", HouseNovalue.Text);
            cmd.Parameters.AddWithValue("@Date", Datevalue.Text);
            cmd.Parameters.AddWithValue("@Time", Timevalue.Text);
            var indoorTemp = cmd.ExecuteScalar();
            Indoortemp.Text = indoorTemp;
        }
    }
