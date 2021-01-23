    void Generate_Chart(DevExpress.XtraCharts.ChartControl chartCtrl,
                       string chart_sourceActualValue,
                        string chart_sourceTable,
                       string chart_benExpValue
                       )
        {
            // Create two stacked bar series.
            Series series1 = new Series("Data", ViewType.Bar);
            Series series2 = new Series("Ben", ViewType.Line);
    
            try
            {                    
                using (var cmd = new SQLiteCommand(m_dbConnection))
                for (int i = LoopMin; i < LoopMax; i++)
                {
                    // Retrieve the actual calculated values from the database
                    cmd.CommandText = "SELECT " + sourceActualValue + " FROM " + 
                         chart_sourceTable + " WHERE Value = " + i + "";
                    Chart_SeriesA_Value = Convert.ToInt32(cmd.ExecuteScalar());
    
                    // Retrieve the expected values from the database
                    cmd.CommandText = "SELECT " + chart_benExpValue + " FROM " + 
                             chart_sourceTable + " WHERE Value = " + i + "";
                    Chart_SeriesB_Value = Convert.ToInt32(cmd.ExecuteScalar());
    
                    // Add the dynamically created values 
                    // to a series point for the chart
                    series1.Points.Add(new SeriesPoint(i, Chart_SeriesA_Value));
                    series2.Points.Add(new SeriesPoint(i, Chart_SeriesB_Value));
                }
            }
            catch (Exception)
            {                
                throw;
            }
    
            // Add both series to the chart.
            chartCtrl.Series.AddRange(new Series[] { series1, series2 });
    
            // Remove the GridLines from the chart for better UI
            // Cast the chart's diagram to the XYDiagram type, to access its axes.
            XYDiagram diagram = (XYDiagram)chartCtrl.Diagram;
            // Customize the appearance of the axes' grid lines.
            diagram.AxisX.GridLines.Visible = false;
            }        
    }
