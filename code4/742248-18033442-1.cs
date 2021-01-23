    [OutputCache(NoStore = true, Duration = 0)]
            public ActionResult GetRegInfoAjax()
            {
                if (TempData["GetRegInfo"] != null)
                {
                    var g = (GetRegInfo)TempData["GetRegInfo"];  
                    return Content(g.sCarmodel);
                }
                else
                {
                    return Content("null");
                }
            }
