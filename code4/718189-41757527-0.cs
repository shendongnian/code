    enter code here
            Microsoft.Office.Interop.Excel.Application oXL = null;
            Workbook oWB    = null;
            Workbooks oWBs  = null;
            Worksheet oSheet    = null;
            Sheets oSheets  = null;
            Range oRng = null;
            
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.DisplayAlerts = false;
                oXL.Visible = false;
                oXL.UserControl = false;
                oWBs = oXL.Workbooks;
                
                var FilePath = @sFilePath +"\\"+ sFbName + ".xlsx";
    
                    oWB = oWBs.Open(FilePath);
             
                oSheets = oWB.Sheets;
                oSheet = (Worksheet)oWB.ActiveSheet;
                //Add table headers going cell by cell.
                oSheet.Cells[4, 5] = "Sr.No";              
     
              
                //AutoFit columns A:D.
                oRng = oSheet.get_Range("E4", "L5000");
                oRng.EntireColumn.AutoFit();
          
                oWB.Save();
                //Close and Quit Logic        
                oWB.Close();
                oXL.Quit();
            }
            catch (Exception we)
            {
                we.ToString();
            }
            finally
            {
                if (oRng != null) { Marshal.ReleaseComObject(oRng); }
                if (oSheet != null) { Marshal.ReleaseComObject(oSheet); }
                if (oSheets != null) { Marshal.ReleaseComObject(oSheets); }
                if (oWBs != null) { Marshal.ReleaseComObject(oWBs); }
                if (oWB != null) { Marshal.ReleaseComObject(oWB); }
                if (oXL != null) { Marshal.ReleaseComObject(oXL); }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
