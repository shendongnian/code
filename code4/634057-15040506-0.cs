    SqlConnection con =
        new SqlConnection(
            @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\fuda\Fuda.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable tl = new DataTable();
    da.SelectCommand = new SqlCommand("Select last_retail_price from pur_temp", con);
    con.Open();
    da.Fill(tl);
    object sum_obj = tl.Compute("sum(last_retail_price)", null);
    total.Text = sum_obj.ToString();
    con.Close();
