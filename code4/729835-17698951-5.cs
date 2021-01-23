    using(SqlCommand prikaz2 = new SqlCommand("INSERT INTO klisluz VALUES(@p1, @p2)",spojeni))
    {
        for(int i=0; i< dtg_ksluzby.Rows.Count;i++)
        {
              prikaz2.Parameters.AddWithValue("@p1", dtg_ksluzby.Rows[i].Cells["text"].Value);
              prikaz2.Parameters.AddWithValue("@p2", dtg_ksluzby.Rows[i].Cells["pocet"].Value);
              prikaz2.ExecuteNonQuery();
              prikaz2.Parameters.Clear();
        }
    }
