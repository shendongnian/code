    var storePosts = session.Load<BlogPost>(externalIds);
    foreach(var storePost in storePosts) {
        if(storePost == null) { // No match will return null
            storePost = GetExternalItem(); // Create a new post
        } else {
            // Update 'storePost' with values from external item
        }
        session.Store(storePost, storePost.ID);
    }
    
    var removedPosts = session.Query<BlogPosts>().Where(x => !externalIds.Contains(x.ID));
    foreach(var removedPost in removedPosts) {
        session.Advanced.Defer(new DeleteCommandData { Key = removedPost.ID });
    }
    
    session.SaveChanges();
