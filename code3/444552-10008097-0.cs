    Blog blog = new Blog();
    blog.Name = "test";
    blog.CreatedAt = DateTime.Now;
    session.SaveOrUpdate(blog);
    var item = new Post(blog);
    blog.Posts.Add(item); // item.Id still 0 here. That mean that no insert was made
