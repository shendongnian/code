    using Excel = Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    var rows = dataGridView1.Rows.Count;
    var columns = dataGridView1.Columns.Count;
    
    var dataAsObjectArray = new object[rows,columns];
    
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            dataAsObjectArray[i, j] = dataGridView1.Rows[i].Cells[j];
        }
    }
    
    Excel.Application application = new Excel.Application();
    Excel.Workbook workbook = application.Workbooks.Add();
    Excel.Worksheet worksheet = workbook.Sheets[1];
    
    Excel.Range range  = worksheet.Range[rows, columns];
    range.Value = dataAsObjectArray;
    
    workbook.SaveAs(@"C:\whatever.xlsx");
    workbook.Close();
    
    Marshal.ReleaseComObject(application);
