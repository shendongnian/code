    using (SqlConnection c = new SqlConnection(connString))
    {
        c.Open();
        using (SqlCommand cmd = new SqlCommand("INSERT INTO [Table] ([Item], [Des1],[Des2], [Prodline], [ANR], [STime]) VALUES(@Item,@Des1,'0',@ProdLine,@ANR,@STime)", c))
        {
            cmd.Parameters.AddWithValue("@Item", txtText1.Text);
            cmd.Parameters.AddWithValue("@Des1", txtText2.Text);
            cmd.Parameters.AddWithValue("@ProdLine", txText3.Text);
            cmd.Parameters.AddWithValue("@ANR", txtText4.Text);
            cmd.Parameters.AddWithValue("@STime", txtText5.Text);
            cmd.ExecuteNonQuery();
        }
    }
