    public JsonResult CheckUserName()
    {
        string userName = Request["UserName"];
    
        var cx = new PostAdPage.Models.mydbEntities3();
    
        // Check unique unsername
        var isUunique = cx.signups.Any(x => x.username.Equals(userName));    
    
        return Json(isUunique, JsonRequestBehavior.AllowGet);
    }
