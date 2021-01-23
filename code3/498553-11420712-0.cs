    IEnumerable<Blog> FindAllBlogByKeywords(IEnumerable<string> keywords)
    {
         IQueryable<Blog> query = context.Blogs;
         foreach(string key in keywords)
             query = query.Where(blog => blog.Keywords.Contains(key));
         // Execute query (optional)
         return query.ToList();
    }
