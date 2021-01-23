     [HttpPost]
     public ActionResult Index(Comment comment)
     {
         if (ModelState.IsValid)
         {
             if(comment.PostID == 0)//New record
                db.Comments.AddObject(comment);
             else // Edit existing comment
                {
                  var OldComment = db.Comments.Where(c => c.PostID == comment.PostID).SingleOrDefault();
                  if (OldComment != null)
                    {
                      OldComment.PostTitle = comment.PostTitle;
                      //Set all other properties...
                    }
                }
             db.SaveChanges();
             return RedirectToAction("CommentResponse");  
         }
    
        ViewBag.PostCommentFK = new SelectList(db.Posts, "PostID", "PostTitle", comment.PostCommentFK);
    return View(comment);
    }
