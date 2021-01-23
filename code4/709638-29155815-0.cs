    foreach (var blog in blogs)
    {
        context.Blogs.Attach(blog);
        context.Entry(blog).Collection(a => a.Comments).Load();
        context.Entry(blog).Reference(a => a.Author).Load();
        // Here you can use blog.Author and blog.Comments with no problem.
    }
