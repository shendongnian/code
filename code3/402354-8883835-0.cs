            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT day FROM observation WHERE day BETWEEN @from AND @to GROUP BY day";
            cmd.Parameters.AddWithValue("from", Convert.ToDateTime(dateFrom));
            cmd.Parameters.AddWithValue("to", Convert.ToDateTime(dateTo));
            cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable("DATA");
            dt.Columns.Add("Hour");
            int days = 0;
            chart1.DataSource = dt;
            while (rdr.Read())
            {
                dt.Columns.Add(((DateTime)rdr[0]).ToString("yyyy-MM-dd"));
                if (days == 0)
                {
                    chart1.Series[days].Name = ((DateTime)rdr[0]).ToString("yyyy-MM-dd");
                }
                else
                {
                    chart1.Series.Add(((DateTime)rdr[0]).ToString("yyyy-MM-dd"));
                }
                chart1.Series[((DateTime)rdr[0]).ToString("yyyy-MM-dd")].XValueMember = "Hour";
                chart1.Series[((DateTime)rdr[0]).ToString("yyyy-MM-dd")].YValueMembers = ((DateTime)rdr[0]).ToString("yyyy-MM-dd");
                chart1.Series[((DateTime)rdr[0]).ToString("yyyy-MM-dd")].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                days++;
            }
            rdr.Close();
            DataRow dr = dt.NewRow();
            for (int i = 1; i < 25; i++)
            {
                dr = dt.NewRow();
                dr["Hour"] = i;
                dt.Rows.Add(dr);
            }
            cmd.CommandText = "SELECT * FROM observation WHERE day BETWEEN @from2 AND @to2 ORDER BY day ASC, hour ASC ";
            cmd.Parameters.AddWithValue("from2", Convert.ToDateTime(fromDate));
            cmd.Parameters.AddWithValue("to2", Convert.ToDateTime(toDate));
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dt.Rows[((int)(rdr[2]) - 1)][(((DateTime)rdr[1]).ToString("yyyy-MM-dd"))] = rdr[3];   
            }
            cmd.Connection.Close();
            rdr.Close();
            dataGridView1.DataSource = dt;
            chart1.DataBind();
            chart1.Visible = true;
