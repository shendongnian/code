        [HttpPost]
        public ActionResult Edit(int articleId, FormCollection collection)
        {
            var result = from i in db.Articles
                         where i.Id == articleId
                         select i;
            if (TryUpdateModel(result.First()))
            {
        
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(result.First());
        }
