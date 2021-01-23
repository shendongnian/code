    // Find our graphs by looping all drawings in the document and comparing their "alt title" property
    foreach (Drawing drawing in mainDocumentPart.Document.Body.Descendants<Drawing>())
    {
        DocProperties docProperties = drawing.Descendants<DocumentFormat.OpenXml.Drawing.Wordprocessing.DocProperties>().FirstOrDefault();
    
        if (docProperties != null && docProperties.Title != null)
        {
            if (docProperties.Title.Value == AltTitleChartBlack || docProperties.Title.Value == AltTitleChartRed)
            {
                LineChartData lineChartData = null;
                switch (docProperties.Title.Value)
                {
                    case AltTitleChartBlack:
                        lineChartData = this.chartDataBlack;
                        break;
                    case AltTitleChartRed:
                        lineChartData = this.chartDataRed;
                        break;
                }
    
                ChartReference chartRef = drawing.Descendants<ChartReference>().FirstOrDefault();
                if (chartRef != null && chartRef.Id != null)
                {
                    ChartPart chartPart = (ChartPart)mainDocumentPart.GetPartById(chartRef.Id);
                    if (chartPart != null)
                    {
                        Chart chart = chartPart.ChartSpace.Elements<Chart>().FirstOrDefault();
                        if (chart != null)
                        {
    
                            LineChart lineChart = chart.Descendants<LineChart>().FirstOrDefault();
    
                            if (lineChart != null)
                            {
                                LineChartEx chartEx = new LineChartEx(chartPart, lineChartData);
                                chartEx.Refresh();
                                chartPart.ChartSpace.Save();
                            }
                        }
                    }
                }
            }
        }
    }
