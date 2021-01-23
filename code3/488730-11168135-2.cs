    Microsoft.Office.Interop.Excel.Application excel = null;
    Microsoft.Office.Interop.Excel.Workbook wb = null;
    object missing = Type.Missing;
    Microsoft.Office.Interop.Excel.Worksheet ws = null;
    Microsoft.Office.Interop.Excel.Range rng = null;      
    try
    {
        excel = new Microsoft.Office.Interop.Excel.Application();
        wb = excel.Workbooks.Add();
        ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                  
        for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
        {
            ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
        }
              
        for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
        {  // <small>hey! I did not invent this line of code, 
           // I found it somewhere on CodeProject.</small> 
           // <small>It works to add the whole row at once, pretty cool huh?</small>
           ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = 
           dt.Rows[Idx].ItemArray;
        }
                
        excel.Visible = true;
        wb.Activate();
    }
    catch (COMException ex)
    {
        MessageBox.Show("Error accessing Excel: " + ex.ToString());
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.ToString());
    }
