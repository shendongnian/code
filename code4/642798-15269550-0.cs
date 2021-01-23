    conn.Open();
    using(SqlCommand cmd = new SqlCommand(sql, conn))
    {
        var now = DateTime.Now;
        foreach (GridViewRow row in GridView1.Rows)
        {
            string myPart = row.Cells[0].Text;
            string myQuantity = row.Cells[1].Text;
            string myPrice = row.Cells[2].Text;
            //... etc
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Item", myPart);
            cmd.Parameters.AddWithValue("@Quantity", myQuantity);
            cmd.Parameters.AddWithValue("@Price", myPrice);
            cmd.Parameters.AddWithValue("@ModelID, methodID);
            cmd.Parameters.AddWithValue("@DateCreatedOn, now);
            cmd.ExecuteNonQuery();
        }
    }
    conn.Close();
