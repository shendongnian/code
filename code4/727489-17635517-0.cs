    for (int i = dvgPerpustakaan.Rows.Count - 1; i >= 0 ; i--)
    {
        DataGridViewRow dr = dvgPerpustakaan.Rows[i];
        if (dr.Selected == true)
        {
            dvgPerpustakaan.Rows.RemoveAt(i);
            try
            {
                using(SqlConnection db = new SqlConnection(con))
                using(SqlCommand dbcmd = db.CreateCommand())
                {
                    db.Open();
                    dbcmd.CommandText = "delete from Perpustakaan where KodeBuku=" + i;
                    dbcmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
    }
