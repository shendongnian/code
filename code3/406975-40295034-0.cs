                        Microsoft.Office.Interop.Excel.ChartObject chartObj = null;
                        Microsoft.Office.Interop.Excel.Chart chart = null;
                        Microsoft.Office.Interop.Excel.Legend legend = null;
                        Microsoft.Office.Interop.Excel.LegendEntries legendEntries = null;
                        Microsoft.Office.Interop.Excel.LegendEntry legendItem;
                        int legendEntryCount = 0;
                        chartObj = (Microsoft.Office.Interop.Excel.ChartObject) xlws.ChartObjects("Chart 1");
                        chart = chartObj.Chart;
                        legend = chart.Legend;
                        legendEntries = (Microsoft.Office.Interop.Excel.LegendEntries) chart.Legend.LegendEntries();
                        legendEntryCount = legendEntries.Count;
                        if (legendEntryCount > 2)
                        {
                            legendItem = (Microsoft.Office.Interop.Excel.LegendEntry) legend.LegendEntries(legendEntryCount);
                            legendItem.Delete();
                            legendItem = (Microsoft.Office.Interop.Excel.LegendEntry) legend.LegendEntries(legendEntryCount - 1);
                            legendItem.Delete();
                        }
