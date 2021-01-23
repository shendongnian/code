    [HttpPost]
        public JsonResult CreateOrUpdate(BrandModel model)
        {
            ViewBag.Id_ProductPackageCategory = new SelectList(db.ProductPackageCategories, "Id_ProductPackageCategory", "Name", person.Id_ProductPackageCategory);
        try
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
                throw new Exception("Please correct the following errors: " + Environment.NewLine + messages);
            }
            db.Persons.AddObject(person);
            db.SaveChanges();
            return Json(new { Result = "OK" });
        }
        catch (Exception ex)
        {
            return Json(new { Result = "ERROR", Message = ex.Message });
        }
    }                                                                                   
