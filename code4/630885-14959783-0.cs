    string query = "select top 0.1 percent Title, Answer1, Answer2, Answer3, Answer4 from [Question] order by newid()";
    using (var con = new SqlConnection("YourConnectionString"))
    using (var cmd = new SqlCommand(query, con))
    {
        con.Open();
        using (var dr = cmd.ExecuteReader())
        {
            if (dr.Read())
            {
                 rbList1.Items.Add(dr.GetString(0));
                 rbList1.Items.Add(dr.GetString(1));
                 rbList1.Items.Add(dr.GetString(2));
                 rbList1.Items.Add(dr.GetString(3));
            }
        }
    }
