     [WebMethod]
            public ChartsClass GetChart(string UserId)
            {
                ChartsClass chart = new ChartsClass();
                DataSet1TableAdapters.WS_ChartIndicatorsTableAdapter adapter  =  new DataSet1TableAdapters.WS_ChartIndicatorsTableAdapter();
                DataSet1.WS_ChartIndicatorsDataTable table = adapter.GetChartIndicators(UserId);
    
                StringBuilder sbDescriptions = new StringBuilder();
                StringBuilder sbValues = new StringBuilder();
    
                for(int i= 0 ;i< table.Rows.Count ;i++)
                {
                    DataSet1.WS_ChartIndicatorsRow chartRow = (table.Rows[i] as DataSet1.WS_ChartIndicatorsRow);
                    if (i > 0)
                    {
                        sbDescriptions.Append("|");
                        sbValues.Append(",");
                    }
    
                    sbDescriptions.Append(chartRow.SectorId + " - " + chartRow.SectorDescription );
                    sbValues.Append(chartRow.NetSaleValue.ToString());
                }
    
                chart.ChartString = String.Format("http://chart.apis.google.com/chart?cht=p3&chtt={0}&chd=t:{1}&chs=480x200&chl={2}&chco=ff0000,0000ff",
                  "Live Sales", sbValues.ToString(), sbDescriptions.ToString());
               
    
                return chart;
            }
