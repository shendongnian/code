    public JsonResult CheckUserName()
    {
        string userName = Request["UserName"];
    
        var cx = new PostAdPage.Models.mydbEntities3();
    
        // Check unique unsername
        var u = cx.signups.SingleOrDefault(x => x.username.Equals(userName));    
    
        if (u != null)
        {
            return this.Json(true, JsonRequestBehavior.AllowGet);
        }
        else
        {
            return this.Json(false, JsonRequestBehavior.AllowGet);
        }
    }
