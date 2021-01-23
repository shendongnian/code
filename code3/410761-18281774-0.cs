    IEnumerable<Post> _post = getAllNewPost();
    
     Using(Datacontext dc = new Datacontext())
        {
            dc.Posts.InsertAllOnSubmit(_post);
            dc.SubmitChanges();
         }
