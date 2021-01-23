        var blogPost = context.BlogPosts
            .Where(b => b.Id == 1)
            .Select(b => new
            {
                BlogPost = b,
                Comments = b.Comments.Where(c => !c.AuditInfo.Deleted.HasValue)
            })
            .SingleOrDefault();
