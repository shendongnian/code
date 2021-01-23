               DataTable dt = GetGroupChartData(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text + " 23:59"));
                ChartSeries chartSeries = new ChartSeries();
                radGroups.Clear();
                chartSeries.DataYColumn = "Tours";
                radGroups.ChartTitle.TextBlock.Text = "Groups";
                chartSeries.Name = "Tours";
                radGroups.PlotArea.XAxis.LayoutMode = Telerik.Charting.Styles.ChartAxisLayoutMode.Inside;
                chartSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Blue; 
                
                //set y axis color
                radGroups.PlotArea.YAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.Red;
                radGroups.PlotArea.YAxis.Appearance.Width = 3;
                radGroups.PlotArea.YAxis.Appearance.Color = System.Drawing.Color.Red; 
                chartSeries.Type = ChartSeriesType.Line;
                radGroups.PlotArea.XAxis.DataLabelsColumn = "dtMonth";
                radGroups.PlotArea.XAxis.AxisLabel.TextBlock.Text = "Months";
                //set x axis color
                radGroups.PlotArea.XAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.Red; 
                radGroups.PlotArea.XAxis.Appearance.Width = 3;
                radGroups.PlotArea.XAxis.Appearance.Color = System.Drawing.Color.Red;
                radGroups.AddChartSeries(chartSeries);
                // visually enhance the data points
                chartSeries.Appearance.PointMark.Dimensions.Width = 5;
                chartSeries.Appearance.PointMark.Dimensions.Height = 5;
                chartSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
                chartSeries.Appearance.PointMark.Visible = true;
                radGroups.DataSource = dt;
                radGroups.DataBind();
