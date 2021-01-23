    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    using System.Runtime.InteropServices;
    public class ExportToExcel
    {
        [Microsoft.SqlServer.Server.SqlProcedure]
    public static void ExportQueryResults(string queryText, string worksheetName, string fileName)
    {
        using (SqlConnection cnn = new SqlConnection("context connection=true"))
        {
            //the temp list to hold the results in
            List<object[]> results = new List<object[]>();
            cnn.Open();
            //create the sql command
            SqlCommand cmd = new SqlCommand(queryText, cnn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int fieldCount = reader.FieldCount;
                object[] headers = new object[fieldCount];
                for (int i = 0; i < fieldCount; i++)
                {
                    headers[i] = reader.GetName(i);
                }
                //read the results
                while (reader.Read())
                {
                    object[] values = new object[fieldCount];
                    for (int i = 0; i < fieldCount; i++)
                    {
                        values[i] = reader[i];
                    }
                    results.Add(values);
                }
                //convert the results into a 2-d array to export into Excel
                object[,] exportVals = new object[results.Count, fieldCount];
                for (int row = 0; row < results.Count; row++)
                {
                    for (int col = 0; col < fieldCount; col++)
                    {
                        exportVals[row, col] = results[row][col];
                    }
                }
                Excel.Application _app = new Excel.Application();
                Excel.Workbook _book = _app.Workbooks.Add(Missing.Value);
                Excel.Worksheet _sheet = (Excel.Worksheet)_book.ActiveSheet;
                Excel.Range _range = (Excel.Range)_sheet.Cells[1, 1];
                _app.DisplayAlerts = false;
                //set the headers and freeze the panes
                _range = _sheet.get_Range(_sheet.Cells[1, 1], _sheet.Cells[1, fieldCount]);
                _range.NumberFormat = "@";
                _range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                _range.Value2 = headers;
                _range.Font.Bold = true;
                _range = _sheet.get_Range(_sheet.Cells[2, 1], _sheet.Cells[2, 1]);
                _range.EntireRow.Select();
                _range.Application.ActiveWindow.FreezePanes = true;
                _range = _sheet.get_Range(_sheet.Cells[2, 1], _sheet.Cells[results.Count, fieldCount]);
                _range.Value2 = exportVals;
                _range = _sheet.get_Range(_sheet.Cells[1, 1], _sheet.Cells[exportVals.Length, fieldCount]);
                _range.AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
                _sheet.Cells.Columns.AutoFit();
                _sheet.Range["A1"].Select();
                _sheet.Name = worksheetName;
                //remove any extra worksheets
                foreach (Excel.Worksheet sht in _book.Worksheets)
                {
                    if (sht.Name != worksheetName)
                        sht.Delete();
                }
                _book.SaveAs(fileName
                    , Excel.XlFileFormat.xlExcel5
                    , Missing.Value
                    , Missing.Value
                    , false
                    , false
                    , Excel.XlSaveAsAccessMode.xlNoChange
                    , Missing.Value
                    , Missing.Value
                    , Missing.Value
                    , Missing.Value
                    , Missing.Value);
                //_book.Close(Missing.Value, Missing.Value, Missing.Value);
                _app.Application.Quit();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(_range);
                Marshal.ReleaseComObject(_sheet);
                Marshal.ReleaseComObject(_book);
                Marshal.ReleaseComObject(_app);
                _range = null;
                _sheet = null;
                _book = null;
                _app = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
    }
