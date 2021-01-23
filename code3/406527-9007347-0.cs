       #region get values from database
            string query = "declare @start datetime, @end datetime select @start = '" + start + "', @end = '" + end + "' select Name,DataDT,Rating,DataGroupID from DATA inner join Channels on Channels.ID = DATA.ChannelID where DataDT >= @start and DataDT < @end and ChannelID<'4'";
            SqlDataReader rdr = null;
            sqlCon = new SqlConnection(Properties.Settings.Default.ConectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 300;
            rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            DataTable table = new DataTable();
            // Add three columns to the table.
            table.Columns.Add("Channel", typeof(String));
            table.Columns.Add("Date", typeof(String));
            table.Columns.Add("Value", typeof(Int32));
            // Add data rows to the table.
            while (rdr.Read())
            {
                table.Rows.Add(new object[] { rdr[0], rdr[1], rdr[2] });
            }
            sqlCon.Close();
            
          
            #endregion
        
        
            // Create a data series
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (chart1.Series.Where(x => x.Name == table.Rows[i][0].ToString()).Count() > 0)
                {
                }
                else
                {
                    Series series = new Series(table.Rows[i][0].ToString());
                    chart1.Series.Add(series);
                }
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (Series series in chart1.Series)
                {
                    if (table.Rows[i][0].ToString() == series.Name)
                    {
                        series.Points.AddXY(Convert.ToDateTime(table.Rows[i][1]).ToShortTimeString(),Convert.ToDouble(table.Rows[i][2]));
                    }
                }
            }
            //Set Properties for chart series
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].XValueMember = "Date";
                chart1.Series[i].YValueMembers = "Value";
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[i].XValueType = ChartValueType.Time;
                chart1.Series[i].ChartType = SeriesChartType.Line;
                chart1.Series[i].MarkerStyle = MarkerStyle.Star10;
                chart1.Series[i].MarkerSize = 8;
                chart1.Series[i].MarkerColor = chart1.Series[0].BorderColor;
                chart1.Series[i].BorderWidth = 3;
                chart1.Series[i].IsValueShownAsLabel = true;
                chart1.Series[i].ToolTip = "#VALY => #AXISLABEL";
            }
              
            chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
        }
