        #region Save & Quit
        //Save and quit, use SaveCopyAs since SaveAs does not always work
        Guid id = Guid.NewGuid();
        string uniqueFileName = id.ToString() + ".xls";
        string fileName = Server.MapPath("~/" + uniqueFileName);
        xlApp.DisplayAlerts = false; //Supress overwrite request
        xlWorkBook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        xlWorkBook.Close(true, misValue, misValue);
        xlApp.Quit();
        //Release objects
        releaseObject(xlWorkSheet);
        releaseObject(xlWorkBook);
        releaseObject(xlApp);
        //Give the user the option to save the copy of the file anywhere they desire
        String FilePath = Server.MapPath("~/" + uniqueFileName);
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment; filename=MyClaimsReport-" + DateTime.Now.ToShortDateString() + ".xls;");
        response.TransmitFile(FilePath);
        response.Flush();
        response.Close();
        //Delete the temporary file
        DeleteFile(fileName);
        #endregion
    private void DeleteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            try
            {
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
                //Could not delete the file, wait and try again
                try
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(fileName);
                }
                catch
                {
                    //Could not delete the file still
                }
            }
        }
    }
