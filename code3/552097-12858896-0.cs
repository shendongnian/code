        foreach (DataRow dataRow in users.Rows)
        {
            Series s = new Series("Userid_" + dataRow["userid"]);
            s.ChartType = SeriesChartType.Spline;
            s.Color = colors[i % colors.Count()];
            var userRows = dataTable.Rows.Cast<DataRow>().Select(r=>r["userid"]==dataRow["userid"]).ToArray();
            s.Points.DataBindXY(userRows,"AddedDate",userRows,"CountElements");
            mainChart.Series.Add(s);
            i++;
        }
