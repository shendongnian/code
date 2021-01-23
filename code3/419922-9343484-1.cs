    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using Excel = Microsoft.Office.Interop.Excel;
    public static class ExcelMod
    {
    
    	
    	public static bool ToExcel(this DataGridView grd, string path, ref Exception exp = null)
    	{
    		bool res = false;
    		exp = null;
    		Excel.Application xlApp = null;
    		Excel.Workbook xlWorkBook = null;
    		Excel.Worksheet xlWorkSheet = null;
    
    		try {
    			System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
    
    			object misValue = System.Reflection.Missing.Value;
    			int i = 0;
    			int j = 0;
    
    			xlApp = new Excel.ApplicationClass();
    			System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    
    			xlWorkBook = xlApp.Workbooks.Add(misValue);
    			xlWorkSheet = xlWorkBook.Sheets("sheet1");
    
    			int lastCol = 0;
    			int lastRow = 0;
    			for (j = 0; j <= grd.ColumnCount - 1; j++) {
    				if (grd.Columns(j).Visible) {
    					xlWorkSheet.Columns(lastCol + 1).ColumnWidth = Convert.ToInt32(grd.Columns(j).Width / 10);
    					xlWorkSheet.Cells(1, lastCol + 1) = grd.Columns(j).HeaderText;
    					lastCol += 1;
    				}
    			}
    
    			lastRow = 0;
    			for (i = 0; i <= grd.RowCount - 1; i++) {
    				lastCol = 0;
    				for (j = 0; j <= grd.ColumnCount - 1; j++) {
    
    					if (grd.Columns(j).Visible && grd.Rows(i).Visible) {
    						if (grd(j, i).FormattedValue != null)
    							xlWorkSheet.Cells(lastRow + 2, lastCol + 1) = grd(j, i).FormattedValue.ToString();
    
    						lastCol += 1;
    
    					}
    				}
    				if (grd.Rows(i).Visible)
    					lastRow += 1;
    			}
    
    
    			xlWorkSheet.SaveAs(path);
    			xlWorkBook.Close();
    			xlApp.Quit();
    
    			System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
    			res = true;
    
    		} catch (Exception ex) {
    			exp = ex;
    		} finally {
    			if (xlApp != null)
    				releaseObject(xlApp);
    			if (xlWorkBook != null)
    				releaseObject(xlWorkBook);
    			if (xlWorkSheet != null)
    				releaseObject(xlWorkSheet);
    		}
    
    		return res;
    	}
    
    	private static void releaseObject(object obj)
    	{
    		try {
    			System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
    			obj = null;
    		} catch (Exception ex) {
    			obj = null;
    		} finally {
    			GC.Collect();
    		}
    	}
    
    }
