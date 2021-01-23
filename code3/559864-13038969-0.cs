                private static Microsoft.Office.Interop.Excel.Application xlApp = null;
                private static Microsoft.Office.Interop.Excel.Workbook xlWb = null;
                private static Microsoft.Office.Interop.Excel.Worksheet xlWs = null;
                //Your code and operations
                xlWb.SaveAs(filePath, XlFileFormat.xlExcel8, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange,
                            Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWs);
                Marshal.ReleaseComObject(xlWb);
                Marshal.ReleaseComObject(xlApp);
