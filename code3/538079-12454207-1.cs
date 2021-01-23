         Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
                ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
                ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
           
                int counter = 1;
                foreach (var item in SomeDataCollection)
                {
                    ObjWorkSheet.Cells[counter, 1] = item.some_property1;
                    ObjWorkSheet.Cells[counter, 2] = item.some_property2;
                    ObjWorkSheet.Cells[counter, 3] = item.some_property3;     
                    counter++;
                }
                ObjWorkSheet.Columns.AutoFit();
                ObjWorkSheet.Columns.get_Range("M1", "M60").ColumnWidth = 25;
		string filename; 	
                string[] file_parts = Convert.ToString(DateTime.Now).Split(' ');
                filename = file_parts[0].Replace("/", ".") + "(" + file_parts[1].Replace(":", "-") + ")" + "-file.xls";
                string save_path = AppDomain.CurrentDomain.BaseDirectory + "Content/files/" + filename;
                ObjWorkBook.SaveAs(save_path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                                                System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                System.Reflection.Missing.Value, System.Reflection.Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                                                System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                System.Reflection.Missing.Value);
                ObjWorkBook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                ObjExcel.Workbooks.Close();
                ObjExcel.Quit();
