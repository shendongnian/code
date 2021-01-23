    Microsoft.Office.Interop.Excel.Application excel = null;
    Microsoft.Office.Interop.Excel.Workbook xls = null;
    excel = new Microsoft.Office.Interop.Excel.Application();
                object missing = Type.Missing;
                object trueObject = true;
                excel.Visible = false;
                excel.DisplayAlerts = false;
                xls = excel.Workbooks.Open(excelFile, missing, trueObject, missing,
                        missing, missing, missing, missing, missing, missing, missing, missing,
                        missing, missing, missing);
