    Series series1 = new Series("Series1", ViewType.Pie3D);
    chartControl.Series.Add(series1);
    series1.DataSource = dt;
    series1.ArgumentScaleType = ScaleType.Qualitative;
    series1.ArgumentDataMember = "CategoryName";
    series1.ValueScaleType = ScaleType.Numerical;
    series1.ValueDataMembers.AddRange(new string[] { "Products" });
    series1.LegendText = series1.ArgumentDataMember;
    
    series1.LegendPointOptions.Pattern = string.Concat("{V}");//or string.Concat("{A}") or string.Concat("{A}:{V}")
    chartControl.Legend.Visible = true;
