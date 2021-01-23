     [HttpPost]
                public ActionResult ActionMethods(ActionModel model)
                {
                    if (model != null)
                    {
                        string contentType = "application/xlx";
                        string fileExtension = ".xlsx";
                        
        
                        DataTable dt = //Set your data which is reflect on excel
        
                        ExcelExport.SaveToExcelFile(dt, strFilePath);
                                
                      return File(strFilePath, contentType, "Reports" + fileExtension);
                            }
                        }
                    }
                    return RedirectToAction("Action");
                }
        
       public static void SaveToExcelFile(System.Data.DataTable dt, string filename)
            {
                Application app = new Application();
                try
                {
                    Workbook wb = app.Workbooks.Add(1);
                    Worksheet ws = (Worksheet)wb.Worksheets[1];
    
    
                    Style ColumnStyle = wb.Styles.Add("Style1", Type.Missing);
                    ColumnStyle.Font.Bold = true;
                    ColumnStyle.Interior.Color = System.Drawing.Color.Yellow;
    
    
                    // export column headers
                    for (int colNdx = 0; colNdx < dt.Columns.Count; colNdx++)
                    {
                        ws.Cells[1, colNdx + 1] = dt.Columns[colNdx].ColumnName;
                        Range exrange = (ws.Cells[1, colNdx + 1]) as Range;
                        exrange.Style = ColumnStyle;
                    }
    
                    // export data
                    for (int rowNdx = 0; rowNdx < dt.Rows.Count; rowNdx++)
                    {
                        for (int colNdx = 0; colNdx < dt.Columns.Count; colNdx++)
                        {
                            ws.Cells[rowNdx + 2, colNdx + 1] = dt.Rows[rowNdx][colNdx];
                        }
                    }
                    wb.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                    wb.Close(false, Type.Missing, Type.Missing);
                }
                finally
                {
                    app.Quit();
                }
    
            }
