            public ActionResult Index(string SelectFilter)
            {
                var _model = new Models.MyModel();
    
                List<SelectListItem> listDDL = new List<SelectListItem>();
                listDDL.Add(new SelectListItem { Text = "11", Value = "11" });
                listDDL.Add(new SelectListItem { Text = "22", Value = "22" });
                listDDL.Add(new SelectListItem { Text = "33", Value = "33" });
                ViewData["ddlList"] = listDDL;
    
    //We add our DDL items to our model, you can add it to viewbag also
    //or you can declare DDL in view with its items too
                _model.ddlList = listDDL;
                return View();
            }
