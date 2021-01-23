    chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Auto;
    
    chart1.DataSource = sqlChartTabel; //sqlChartTable is my DataTable
    // Assigning new Data to the charts
    chart1.Series.Clear();   // clearing chart series (after the DataTable is assigned with data)
    chart1.Series.Add("Violations");
    chart1.Series["Series1"].XValueMember = "Month_name";
    chart1.Series["Series1"].YValueMembers = "Salary";
    chart1.ChartAreas["ChartArea1"].AxisX.Title = "Months";
    chart1.ChartAreas["ChartArea1"].AxisY.Title = "Salary";
    chart1.DataBind();
    chart1.Visible = true;
