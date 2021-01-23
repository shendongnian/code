    using (SqlCommand prikaz2 = new SqlCommand("INSERT INTO klisluz values('@val1', '@val2')",spojeni))
    {
      for (int i = 0; i < dtg_ksluzby.Rows.Count; i++)
      {
        prikaz2.Parameters.Clear();
        prikaz2.Parameters.AddWithValue("@val1", dtg_ksluzby.Rows[i].Cells["text"].Value);
        prikaz2.Parameters.AddWithValue("@val2", dtg_ksluzby.Rows[i].Cells["pocet"].Value);
        prikaz2.ExecuteNonQuery();
      }
    }
