    // GET: /Cats/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Cat cat = _catRepository.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            EditCatDetailsViewModel model = new EditCatDetailsViewModel();
            model.cat = cat;
            model.catId = cat.Id;
            return View(model);
        }
