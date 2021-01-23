        chart1.Series.Clear();
        List<string> years = new List<string> { "1994", "1995", "1996", "1997" };
        List<double> yearSales = new List<double> { 10000.23, 98000, 95876, 78097 };
        Series yearSeries = chart1.Series.Add("sales");
        yearSeries.Points.DataBindXY(years, yearSales);
        yearSeries.ChartType = SeriesChartType.Line;
        // do stuff....
        // add one more value
        
        years.Add("1998");
        yearSales.Add(12345.67);
        yearSeries.Points.DataBindXY(years, yearSales);
