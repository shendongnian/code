        private void EnableChart(Series series)
        {
            if (series != null)
            {
                chart1.Series.Clear();
                chart1.Series.Add(series);
                double maxval = series.Points.FindMaxByValue("X").XValue;
                chart1.DataSource = series;
                chart1.ChartAreas[0].AxisX.Title = series.Name;
                //switch latest lines and you haven't to recalculate axes
                chart1.ChartAreas[0].AxisX.Maximum = maxval;
                chart1.DataBind();
            }
        }
