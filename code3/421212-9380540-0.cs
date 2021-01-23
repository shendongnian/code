    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (fpManualCostActual.HasFile)
            {
                    string filePath = Server.MapPath("~/Upload/" + 
                           SessionManager.UID.ToString() + "/MonthlyActual" + 
                           DateTime.Now.ToString("MMddyyyyHHmmss") + fileExt);
                    fpManualCostActual.SaveAs(filePath);
           
            }
         }
        catch (Exception ex)
        {
            CustomException(ex, CommonHelper.ExceptionType.DBExceptionPolicy);
        }
    }
