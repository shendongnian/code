    DataTable dt = new DataTable();
            List<DateTime> list = new List<DateTime>();
            
            SqlCommand cmd = new SqlCommand("select holiday from holidays1", conn);
            SqlDataAdapter da;
            da = new SqlDataAdapter(cmd);
            dt.Clear();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                list.Add(Convert.ToDateTime(dt.Rows[i][0]));
            }
            return list;
