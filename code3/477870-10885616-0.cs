    var blogWithSetting = context.Blogs
        .Where(b => b.BlogId == blogId)
        .Select(b => new
        {
            Blog = b,
            BlogSetting = b.BlogSettings.FirstOrDefault(bs => bs.UserId == userId)
        })
        .SingleOrDefault();
    if (blogWithSetting != null)
    {
        Blog blog = blogWithSetting.Blog;
        //
    }
