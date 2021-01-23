    using (SqlConnection cs = new SqlConnection(@"Server=10-nuerp-006acdst;Database=Rert;User Id=reports;Password=Password"))
    {
        cs.Open();
        using (SqlCommand cmd = new SqlCommand("select top 1 * from station", cs))
        using (SqlDataReader dr = command.ExecuteReader())
        {
            while (dr.Read())
            {
                textbox1.Text = dr.GetSqlValue(1).ToString();
                MessageBox.Show(dr.GetSqlValue(0).ToString());
            }
        }
    }
