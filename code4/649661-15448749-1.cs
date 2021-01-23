    // /Models/BlogPost.cs
    public class BlogPost
    {
        public string Heading { get; set; }
        public string Text { get; set; }
    }
    
    // /Controllers/PostsController
    public class PostsController : Controller
    {
        public ActionResult Details(string id)
        {
            BlogPost model = GetModel(id);
            
            if (model == null)
                return new HttpNotFoundResult();
    
            return View(model);
        }
    
        private BlogPost GetModel(string blogPostId)
        {
            // Getting blog post with the given Id from the database
        }
    }
