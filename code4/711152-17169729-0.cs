        [HttpPost]
        public ActionResult Update(int? id, FormCollection form)
        {
            // assumes repository will handle
            // retrieving the entity and
            // including and navigational properties
            var entity = repository.Get(id);
            if (entity == null)
            {
                throw new InvalidOperationException(string.Format("Not found: {0}", id));
            }
            if (TryUpdateModel(entity))
            {
                try
                {
                    //
                    // do other stuff, add'l validation, etc
                    repository.Update(entity);
                }
                catch (Exception ex)
                {
                    //
                    // exception cleansing/handling
                    // add'l model errors
                    return View(entity);
                }
                return View("Success", entity);
            }            
            return View(entity);
        }
