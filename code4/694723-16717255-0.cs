    public ActionResult GetFolderList(int? parent)
    {
        List<String> folderList = new List<String>();
        folderList.Add("East Midlands");
        folderList.Add("West Midlands");
        folderList.Add("South West");
        folderList.Add("North East");
        folderList.Add("North West");
        if(Request.IsAjaxRequest())
        {
            return Json(folderList);
        }
        return View("someView", folderList );
    
    }
