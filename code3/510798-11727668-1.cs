    public JsonResult GetSites()
    {
       var list=new List<Site>();
       list.Add(new Site{ SiteID=1, SiteName="SiteName 1" } );
       list.Add(new Site{ SiteID=2, SiteName="SiteName 2" } );
       //13 more times !!!!
      return Json(list, JsonRequestBehavior.AllowGet);  
    }
