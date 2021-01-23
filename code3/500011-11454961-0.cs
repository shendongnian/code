    LateBindingApi.Core.Factory.Initialize();    
    Excel.Application app = new Excel.Application();
    Excel.Workbook wb = app.Workbooks.Open(<path to csv>);
    Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
    Excel.Chart chart = ((Excel.ChartObjects)ws.ChartObjects()).Add(0, 0, 100, 100).Chart; //the numbers are position and dimensions of the chart
    chart.ChartWizard(); // here you have to format your chart, see [MSDN documentation][2]
    wb.SaveAs(<output path and format>);
