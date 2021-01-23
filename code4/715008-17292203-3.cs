    using (var context = new BloggingContext())
    {
       context.Entry(blog).State = blog.BlogId == 0 ? EntityState.Added : EntityState.Modified;
         
       context.SaveChanges();
    }
