      [HttpPost]
      public ActionResult Index(UploadNewsModel newsmodel)
    {
        // If not Valid
        if (!ModelState.IsValid)
        {
           return this.View(newsmodel);
        }
        HttpPostedFileBase general = newsmodel.GenearlNews;
        HttpPostedFileBase sport = newsmodel.SportNews;
        HttpPostedFileBase business = newsmodel.BusiNews;
        HttpPostedFileBase international = newsmodel.InterNews;
        HttpPostedFileBase entertainment = newsmodel.EntertaintNews;
    
    
        if (general.ContentLength > 0 && general != null && ...check generalnews validation using data annotation == valid.. )
        {
            var fileName = Path.GetFileName(general.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads/News/General News/"), fileName);
            general.SaveAs(path);
        }
        else
        {
            .... add error of data annotation plus  below
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
        }
    
         ......... same for remaining upload file
        return View(newsmodel);
    }
