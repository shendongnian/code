    public ViewResult Details(int id)
    {
        Blog blog = db.Blogs.Find(id);
        BlogDetailViewModel viewModel = new BlogDetailViewModel {Blog = blog, Comment = ""};
        return View(viewModel);
    }
