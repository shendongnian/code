    [Authorize]
        [HttpPost]
        public ActionResult Create(CreateNewsViewModel HttpPostedFileBase file)// add this 
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                    car.ImagePath = file.FileName;
                }
            // the rest of the code... 
    
            }
            else
            {
                return View(input);
            }
        }
