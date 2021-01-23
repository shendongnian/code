    public class CommentController : Controller
    {
        //
        // GET: /Comment/
        public ActionResult Index()
        {
            return View(new Comment());
        }
        [HttpPost]
        public ActionResult CommentForm(Comment comment)
        {
            Comment ajaxComment = new Comment();
            ajaxComment.CommentText = comment.UserName;
            ajaxComment.DateCreated = comment.DateCreated ?? DateTime.Now;
            ajaxComment.PostId = comment.PostId;
            ajaxComment.UserName = comment.UserName;
            //mRep.Add(ajaxComment);
            //uow.Save();
            //Get all the comments for the given post id
            return Json(ajaxComment);
        }
    }
