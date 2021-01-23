    private void RefreshBlogPosts(IDocumentSession session, IList<BlogPost> parsedPosts) {
        var parsedPostsIds = parsedPosts.Select(x => x.Id);
        var storePosts = session.Load<BlogPost>(parsedPostsIds);
        // Update existing or create new posts
        for(int i = 0; i < storePosts.Count(); i++) {
            var parsedPost = parsedPosts[i];
    
            var storePost = storePosts[i];
            if(storePost == null) {
                storePost = parsedPost;
    
                session.Store(storePost);
            } else {
                // Update post's properties
            }
        }
        // Find posts IDs no longer in database
        var removedPostIds = session.Query<BlogPost>().Select(x => x.Id)
            .Where(postId => !parsedPostsIds.Contains(postId));
        
        foreach(var removedPostId in removedPostIds) {
            session.Advanced.Defer(new DeleteCommandData() { Key = removedPostId });
        }
        session.SaveChanges();
    }    
