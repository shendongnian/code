    [HttpPost]
        [Authorize]
        public ActionResult Upload(HttpPostedFileBase file, CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var FileExtension = Path.GetExtension(file.FileName);
                    string Path1 = null;
                    string FileName = null;
                    do
                    {
                        var randomName = Path.GetRandomFileName();
                        FileName = Path.ChangeExtension(randomName, FileExtension);
                        Path1 = Path.Combine(Server.MapPath("~/Images"), FileName);
                    } while (System.IO.File.Exists(Path1));
                    file.SaveAs(Path1);
                    if (UploadService.SaveImage(FileName, System.Web.HttpContext.Current.User.Identity.Name, model.SelectedCategoryId))
                    {
                        return RedirectToAction("Uploaded", "Upload");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            //I don't know how you fetch this list, but just do it again before returning
            //the view
            model.Categories = GetMyCategories();
            return View(model);
        }
