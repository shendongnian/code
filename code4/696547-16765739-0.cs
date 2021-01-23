     Series series1 = new Series("Series1", ViewType.Pie3D);
    
        chartControl.Series.Add(series1);
    
        series1.DataSource = dt;
        series1.ArgumentScaleType = ScaleType.Qualitative;
        series1.ArgumentDataMember = "CategoryName";
        series1.ValueScaleType = ScaleType.Numerical;
        series1.ValueDataMembers.AddRange(new string[] { "Products" });
       // series1.LegendText = series1.ArgumentDataMember;
       series1.PointOptions.PointView = PointView.Argument; //this is code that you want
      //if you only legend box change
      series1.LegendPointOptions.PointView = PointView.Argument;
        chartControl.Legend.Visible = true;
