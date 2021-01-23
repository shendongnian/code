    using(SqlConnection con = new SqlConnection(@" Data Source=HOME-D2CADC8D4F\SQL;Initial Catalog=motociclete;Integrated Security=True"))
    using(SqlCommand cmd = new SqlCommand("Delete from motociclete where codm=@id", con))
    {
        con.Open();
        cmd.Parameters.AddWithValue("@id", 0);
        for (int i = dataGridView1.Rows.Count-1; i >= 0; i++)
        {
            DataGridViewRow dr = dataGridView1.Rows[i];
            if (dr.Selected == true)
            {
                dataGridView1.Rows.RemoveAt(i);
                cmd.Parameters["@id"].Value = i;
                cmd.ExecuteNonQuery();
            }
        }
    }
