    Blog blog = new Blog();
    session.FlushMode = FlushMode.Always;
    session.SaveOrUpdate(blog);
    var item = new Post(blog);
    blog.Posts.Add(item);
    var blogs = session.QueryOver<Blog>().List();
