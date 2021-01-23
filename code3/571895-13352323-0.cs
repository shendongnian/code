            Chart1.DataSource = dt;
            int amountofrows = Convert.ToInt32(dt.Rows[0]["antal"].ToString());
            for (int i = 0; i < amountofrows; i++)
			{
                List<string> xvals = new List<string>();
                List<decimal> yvals = new List<decimal>();
                string serieName = dt.Rows[i]["doman_namn"].ToString();
                Chart1.Series.Add(serieName);
                Chart1.Series[i].ChartType = SeriesChartType.Line;
                foreach(DataRow dr in dt.Rows)
                {
                    try
                    {
                   
                    if (String.Equals(serieName,dr["doman_namn"].ToString(), StringComparison.Ordinal))     
                    {                    
                        xvals.Add(dr["ranking_date"].ToString());
                        yvals.Add(Convert.ToDecimal(dr["ranking_position"].ToString()));              
                    }
                    }
                    catch (Exception)
                    {
                        throw new InvalidOperationException("Diagrammet kunde inte ritas upp");
                    }
                }
                try
                {
                    Chart1.Series[serieName].XValueType = ChartValueType.String;
                    Chart1.Series[serieName].YValueType = ChartValueType.Auto;
                    Chart1.Series[serieName].Points.DataBindXY(xvals.ToArray(), yvals.ToArray());
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Kunde inte bind punkterna till Diagrammet");
                }    
			}
            Chart1.DataBind();
            Chart1.Visible = true;
