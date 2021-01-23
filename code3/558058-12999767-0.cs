            ...
            DataTable dt = new DataTable("test");
            dt.Columns.Add("test");
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = reader.GetValue(0).ToString();
                    dt.Rows.Add(dr);
                }
            }  
            dataGridView1.DataSource = dt;
            ....
