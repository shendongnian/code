    Blog blog;
    
    using (BloggingContext db = new BloggingContext())
    {
        blog = db.Blogs.Include("Posts").Single();
    }
    
    {
        Post post = new Post {Blog = blog, Title = "Title", Content = "Content"};
        post.blogId = blog.Id;
    }
    
    using (BloggingContext db = new BloggingContext())
    {
        db.Posts.Add(post);
        db.SaveChanges();
    }
