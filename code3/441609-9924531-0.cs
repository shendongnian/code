            Excel.Application xlApp = new Excel.Application();
            xlApp.ScreenUpdating = false;
            try
            {
                xlApp.DisplayAlerts = false;
                vk_filename = SFileName;
             
                //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(SFileName);
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(
                SFileName, vk_update_links, vk_read_only,
                vk_format, vk_password,
                vk_write_res_password,
                vk_ignore_read_only_recommend, vk_origin,
                vk_delimiter, vk_editable, vk_notify,
                vk_converter, vk_add_to_mru,
                vk_local, vk_corrupt_load);
                Excel._Worksheet xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                
				// loop trough cell range and excel rows below will search in 1st row
                Excel.Worksheet worksheet = xlRange.Worksheet;
                for (int iCount = 1; iCount <= colCount; iCount++)
                {
                    string cellValue = "";
                    string  fldValue = "";
 
                    Microsoft.Office.Interop.Excel.Range fldRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, iCount];
                    if (fldRange.Value2 != null)
                    {
                        fldValue = fldRange.Value2.ToString().Trim().ToLower();
                    }
                    else
                    {
                        fldValue = null;
                    }
                    Microsoft.Office.Interop.Excel.Range CellRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, iCount];
                    if (CellRange.Value2 != null)
                    {
                        cellValue = CellRange.Value2.ToString().Trim().ToLower();
						if (cellvalue == valtosearch)
						{ 
						   countOccurence +=1;
						}						
                    }
                    else
                    {
                        cellValue = null;
                    }
                   
                 }
                xlWorkbook.Close(vk_save_changes, vk_filename, vk_route_workbook);
                //xlWorkbook.Save();
                xlApp.Quit();
                return true;
            }
            catch
            {
                xlApp.Quit();
                return false;
            }
        }
