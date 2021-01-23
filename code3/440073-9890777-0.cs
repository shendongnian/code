            chart1.Series.Clear();
            string[] months = { "Jan", "Feb", "Mar", "Apr" };
            double[] thisYearSales = { 10000.23, 98000, 95876, 78097 };
            double[] lastYearSales = { 99000, 99000, 90876, 88097 };
            Series thisYear = chart1.Series.Add("this year");
            thisYear.Points.DataBindXY(months, thisYearSales);
            Series lastYear = chart1.Series.Add("last year");
            lastYear.Points.DataBindXY(months, lastYearSales);
            lastYear.ChartType = SeriesChartType.Line;
