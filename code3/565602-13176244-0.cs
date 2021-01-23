            [HttpPost]
            public ActionResult Create(CatalogItemModel catalogitemmodel, HttpPostedFileBase ImageFile)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    catalogitemmodel.Image =  ms.ToArray();
                }
                
                if (ModelState.IsValid)
                {
                    db.CatalogItemModels.Add(catalogitemmodel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                return View(catalogitemmodel);
            }
