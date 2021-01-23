    Series sr = new Series();
    sr.Name = "A";
    sr.Points.DataBindXY(xValues, yValues);
    sr.ChartType = SeriesChartType.StackedBar;
    sr.Font = new System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Bold);
    for (int i = 0 ; i < xValues.Lenght; i++) //xValues.Lenght = 4 in this case where you have 4 Data number
    { 
        if(i == 0) // Don't forget xValues[0] is Data4 in your case
            sr.Points[i].Color = Dr.Color.Black;
        else
            sr.Points[i].Color = Dr.Color.Yellow;
    }
