    var storePosts = session.Load<BlogPost>(externalIds);
    foreach(var storePost in storePosts) {
        if(storePost == null) { // No match will return null
            storePost = GetExternalItem(); // Create a new post
            session.Store(storePost, storePost.ID);
        } else {
            // Update 'storePost' with values from external item
        }
    }
    
    var removedPosts = session.Query<BlogPosts>().Where(x => !x.ID.In(externalIds));
    foreach(var removedPost in removedPosts) {
        session.Advanced.Defer(new DeleteCommandData { Key = removedPost.ID });
    }
    
    session.SaveChanges();
