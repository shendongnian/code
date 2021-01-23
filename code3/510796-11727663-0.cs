    public JsonResult GetSites()
    {
        var sitesArray = new vAaiomsSitesVM[]
            {
                new vAaiomsSitesVM
                {
                    ID = 1,
                    SiteName = "Barter Island"
                },
                
                new vAaiomsSitesVM
                {
                    ID = 2,
                    SiteName = "Cape Lisburne"
                }
                
                // And so on...
            };
        var sites = sitesArray.OrderBy(s => s.SiteName);
        return Json(sites, JsonRequestBehavior.AllowGet);
    }
