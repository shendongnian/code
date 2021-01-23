    public class CommentsController : Controller
    {
        /** I'm using static to persist data for testing only. */
        private static CommentsViewModel _viewModel;
        public ActionResult Index()
        {
            _viewModel = new CommentsViewModel();
            return View(_viewModel);
        }
        [HttpPost]
        public ActionResult AddNewComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _viewModel.comments.Add(new Comment() {commentData = comment.commentData});
                return View("Index", _viewModel);
            }
            return RedirectToAction("Index");
        }
    }
