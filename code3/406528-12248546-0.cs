    DataTable table = new DataTable();
    
    sqlConnection.Open();
    SqlCommand cmd = new SqlCommand(query, sqlConnection);
    cmd.CommandType = CommandType.Text;
    cmd.CommandTimeout = 300;
    rdr = cmd.ExecuteReader();
    table.Load(rdr);        
         
    Chart1.DataBindCrossTable(table.AsEnumerable(), "Channel", "Date", "Value", "");
    
    for (int i = 0; i < Chart1.Series.Count; i++)
    {
       LegendItem legendItem = new LegendItem();
       legendItem.Name = Chart1.Series[i].Name;
       legendItem.BorderWidth = 1;
       legendItem.ShadowOffset = 1;
       legendItem.Color = Color.FromName(Chart1.Series[i].Color.Name.ToString());
                        
       Chart1.Series[i].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
       Chart1.Series[i].BorderWidth = 3;
       Chart1.Series[i].ToolTip = "#VALY/#VALY2 => #AXISLABEL";
       Chart1.Series[i].IsValueShownAsLabel = true;
       Chart1.Series[i].IsVisibleInLegend = true;
    }
                
