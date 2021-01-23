        System.Data.DataTable dt = ds.Tables[0];
            dt.Columns.Add("testrow", typeof(int));
            DataRow dr = dt.NewRow();
            int sum = 0;
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                for (int j = 1; j < dt.Rows.Count; j++)
                {
                  
                    if (j == dt.Rows.Count - 1)
                    {
                        dt.Rows[i][j] = Convert.ToInt32(sum);
                        sum = 0;
                }
                    else
                    {
                        object number = dt.Rows[i][j];
                       sum += Convert.ToInt32(number);
                    }
                   
                  }
                dataGridView1.DataSource = dt;
            }
