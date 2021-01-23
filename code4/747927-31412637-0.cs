    using Excel = Microsoft.Office.Interop.Excel;
    		
    private void btnExportToExcel_Click(object sender, EventArgs e)
    {
    	SaveFileDialog sfd = new SaveFileDialog();
    	sfd.Filter = "Excel Documents (*.xls)|*.xls";
    	sfd.FileName = "Inventory_Adjustment_Export.xls";
    	if (sfd.ShowDialog() == DialogResult.OK)
    	{
    		// Copy DataGridView results to clipboard
    		copyAlltoClipboard();
    
    		object misValue = System.Reflection.Missing.Value;
    		Excel.Application xlexcel = new Excel.Application();
    
    		xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
    		Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
    		Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
    		// Format column D as text before pasting results, this was required for my data
    		Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
    		rng.NumberFormat = "@";
    
    		// Paste clipboard results to worksheet range
    		Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
    		CR.Select();
    		xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
    
    		// For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
    		// Delete blank column A and select cell A1
    		Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
    		delRng.Delete(Type.Missing);
    		xlWorkSheet.get_Range("A1").Select();
    
    		// Save the excel file under the captured location from the SaveFileDialog
    		xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
    		xlexcel.DisplayAlerts = true;
    		xlWorkBook.Close(true, misValue, misValue);
    		xlexcel.Quit();
    
    		releaseObject(xlWorkSheet);
    		releaseObject(xlWorkBook);
    		releaseObject(xlexcel);
    
    		// Clear Clipboard and DataGridView selection
    		Clipboard.Clear();
    		dgvItems.ClearSelection();
    
    		// Open the newly saved excel file
    		if (File.Exists(sfd.FileName))
    			System.Diagnostics.Process.Start(sfd.FileName);
    	}
    }
    
    private void copyAlltoClipboard()
    {
    	dgvItems.SelectAll();
    	DataObject dataObj = dgvItems.GetClipboardContent();
    	if (dataObj != null)
    		Clipboard.SetDataObject(dataObj);
    }
    
    private void releaseObject(object obj)
    {
    	try
    	{
    		System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
    		obj = null;
    	}
    	catch (Exception ex)
    	{
    		obj = null;
    		MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
    	}
    	finally
    	{
    		GC.Collect();
    	}
    }
