        [HttpPost]
        public ActionResult Create(CommentCreateModel model)
        {
            if (ModelState.IsValid)
            {
               //Do your database insert etc here...
                return Json(new { error = false, message = "Comment added" });
            }
            else
            {
                return Json(new { error = true, message = "The values entered are not valid" });
            }
        }
