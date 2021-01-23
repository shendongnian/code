    using Microsoft.Office.Interop.Excel;
    
    class Program
    {
        const string fileName = "C:\\Book1.xlsx";
        const string topLeft = "A1";
        const string bottomRight = "A4";
        const string graphTitle = "Graph Title";
        const string xAxis = "Time";
        const string yAxis = "Value";
        static void Main()
        {
            // Open Excel and get first worksheet. 
            var application = new Application();
            var workbook = application.Workbooks.Open(fileName);
            var worksheet = workbook.Worksheets[1] as 
                Microsoft.Office.Interop.Excel.Worksheet;
            // Add chart.
            var charts = worksheet.ChartObjects() as 
                Microsoft.Office.Interop.Excel.ChartObjects;
            var chartObject = charts.Add(60, 10, 300, 300) as 
                Microsoft.Office.Interop.Excel.ChartObject;
            var chart = chartObject.Chart;
            // Set chart range.
            var range = worksheet.get_Range(topLeft, bottomRight);
            chart.SetSourceData(range);
            // Set chart properties.
            chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
            chart.ChartWizard(Source: range, Title: graphTitle, CategoryTitle: xAxis, 
                ValueTitle: yAxis);
            
            // Save.
            workbook.Save();
            // Dispose objects.
            worksheet.Dispose();
            workbook.Dispose();
            application.Dispose();
        }
    }
