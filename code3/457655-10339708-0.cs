    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
        var posts = (from p in db.Set<BlogPost>()
                     orderby p.DateCreated descending 
                     select new PostViewModel
                                {
                                    Title = p.Title,
                                    DateCreated = p.DateCreated,
                                    Content = p.Content,
                                    Topics = p.Topics,
                                    Comments = p.Comments,
                                    CommentCount = p.Comments.Count
                                });
        var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
        posts = posts.ToPagedList(pageNumber, 25); // will only contain 25 posts max because of the pageSize
        var blog = new BlogViewModel
        {
            Post = posts,
            Topics = topics.Select(t => new SelectListItem { 
                Value = Convert.ToString(t.id),
                Text = t.Name
            })
        };
        return View(blog);
        }
    }
