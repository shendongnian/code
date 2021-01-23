     static void Main(string[] args)
            {
               var app = new Microsoft.Office.Interop.Excel.Application();
                
                    var workbook = app.Workbooks.Open(@"C:\Users\user\Desktop\Book1.xlsx");
                    Microsoft.Office.Interop.Excel.Worksheet Sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item("Sheet1");
                    string formula = Sheet1.Cells[5][3].Formula;
                    Sheet1.Cells[5][4].Formula = app.ConvertFormula(formula, XlReferenceStyle.xlA1, XlReferenceStyle.xlR1C1, XlReferenceType.xlRelative, Sheet1.Cells[5][3]);
                    workbook.SaveAs(@"C:\Users\user\desktop\test.xlsx");
                    workbook.Close();
            }   
