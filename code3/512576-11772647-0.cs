    public class CommentsController : Controller
    {
        [HttpPost]
        public ActionResult WriteComment(CommentModel comment)
        {
            // Do the basic model validation and other stuff
            try
            {
                if (ModelState.IsValid )
                {
                     // Insert the model to database like:
                     db.Comments.Add(comment);
                     db.SaveChanges();
                     // Pass the comment's article id to the read action
                     return RedirectToAction("Read", "Articles", new {id = comment.ArticleID});
                }
            }
            catch
            {
            }
            // Something went wrong
            return View(comment);
        }
    }
    
    public class ArticlesController : Controller
    {
        // id is the id of the article
        public ActionResult Read(int id)
        {
            // Get the article from database by id
            var model = db.Articles.Find(id);
            // Return the view
            return View(model);
        }
    }
