    Microsoft.Office.Interop.Excel.Application excel = null;
    Microsoft.Office.Interop.Excel.Workbook xls = null;
    try
    {
         excel = new Microsoft.Office.Interop.Excel.Application();
         object missing = Type.Missing;
         object trueObject = true;
         try
         {
              excel.Visible = false; // or true
              excel.DisplayAlerts = false;
         }
         catch(Exception e)
         {
                    Console.WriteLine("-------Error hiding the application-------");
                    Console.WriteLine("Occured error might be: " + e.StackTrace);
         }
         xls = excel.Workbooks.Open(excelFile, missing, trueObject,    missing,missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
         //xls = excel.Workbooks.Open(@"file.xls", missing, trueObject,    missing,missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
    }
    catch (Exception ex)
    {
                MessageBox.Show("Error accessing Excel document.\n\n" +
                ex.Message);
    }
    // Must be surrounded by try catch to work.
    // http://naimishpandya.wordpress.com/2010/12/31/hide-power-point-application-window-in-net-office-automation/
