        public void UpdateForMyView1(EntityBlogPost post)
        {
            this.dbContext.EntityBlogPosts.Attach(post);
            this.dbContext.Entry(post).Property(p => p.Title).IsModified = true;
            this.dbContext.Entry(post).Property(p => p.Description).IsModified = true;
            this.dbContext.SaveChanges();
        }
