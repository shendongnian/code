    private static void UploadFile(string status, string fileNumber)
    {
        var currentPath = ConfigurationManager.AppSettings["FilePath"]; 
        string filename = fileNumber + ".pdf";
        UploadHandler.SaveUploadedFile(Path.GetDirectoryName(currentPath), filename);
    }
    
    [HttpPost]
    public ActionResult PostFile(string newfileName, string fileNumber)
    {
        var isAjax = Request.IsAjaxRequest();
        
        try
        {
            UploadFile(newfileName, fileNumber);
        }
        catch (Exception ex)
        {
            if(isAjax)
            {
                return Json(new { success = false, message = ex.Message }, "text/html");
            }
            
            return Content(ex.ToString());
        }
        
        if(isAjax)
        {
            return Json(new { success = true }, "text/html"); 
        }
        return Content("success");
    }
