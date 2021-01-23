    var chartStartegyFactory = new ChartStrategyFactory();
    var chartStategy = chartStartegyFactory.Create(ddlApplication.SelectedItem.Text, ddlTests.SelectedItem.Text);
    var chart = chartStategy.CreateChart();
    lblTotalTestsRapp.Text = chart.ChartData;
    SpecificTestsRapp.ChartTitle = chart.ChartTitle;
    TotalTestsWeb6.Visible = chart.TotalTestsWeb6Visible;
    // continue assigning properties in your UI
