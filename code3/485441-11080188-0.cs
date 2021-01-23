        //
        // POST: /Blog/Comment/5
        [HttpPost]
        public ActionResult Comment(int id, Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.AddObject(comment);
                comment.PostReference.EntityKey = new EntityKey("BlogEntities.Posts", "id", id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
