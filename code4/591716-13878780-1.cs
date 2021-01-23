    using (BloggingContext db = new BloggingContext())
    {
        // No idea what I have to do before saving...
        db.Attach(blog);
        Post post = new Post {Blog = blog, Title = "Title", Content = "Content"};
        blog.Posts.Add(post);
        db.SaveChanges();
    }
