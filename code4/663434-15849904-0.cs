    Excel.Application XlApp = null;
    Excel.Workbook workbook = null;
    Excel.Worksheet Ws = null;
    Excel.Range Range1 = null;
    Excel.RangeDataRange = null;
    XlApp = new Excel.Application();
    XlApp.Visible = true;
    workbook = XlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
    Ws = (Excel.Worksheet)workbook.Worksheets[1];//Lets say you have your graph at 1 sheet
    XlApp.WindowState = XlWindowState.xlMaximized;
    Ws.Cells.Clear();//Clear your sheet of any existing data
    ChartObjs = null;
    ChartObj = null;
    xlChart = null;
    Range1 = Ws.get_Range(Ws.Cells[39, 6], Ws.Cells[48, 10]);
    ChartObjects WsChartObjs = (ChartObjects)Ws.ChartObjects(Type.Missing);
    ChartObj = WsChartObjs.Add((double)Range1.Left + 115, (double)Range1.Top - 1,  (double)Range1.Width - 25, (double)Range1.Height + 5);
    xlChart = ChartObj.Chart;
    DataRange = null;
     if (MyDataset.Tables[0].Rows.Count > 10)
     {
       DataRange = Ws.get_Range(Ws.Cells[12, 14], Ws.Cells[12 + 
       MyDataset.Tables[0].Rows.Count, 15]);//or whatever your range may be
     }
     
      xlChart.SetSourceData(DataRange, System.Type.Missing);
      xlChart.ChartType = XlChartType.xlBarClustered;
      xlChart.ChartArea.Fill.Visible =            
      Microsoft.Office.Core.MsoTriState.msoFalse;
      xlChart.ChartArea.Border.Color = 
      System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
      xlChart.PlotArea.Interior.Color =  
      System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));
      xlChart.PlotArea.Border.Color = System.Drawing.ColorTranslator.ToOle(255, 255, 255));
