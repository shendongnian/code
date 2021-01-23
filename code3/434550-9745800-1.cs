    public ActionResult Upload()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase file)
    {
        if (file != null)
        {
            file.SaveAs(Server.MapPath("~/App_Data/Uploads/" + file.FileName));
        }
        return View();
    }
