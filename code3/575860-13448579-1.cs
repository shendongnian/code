    public IPostable GetPost(Guid id)
    {
        //id is a property of IPostable, so everything is easy
    }
    
    //you can easily get the real type
    public T GetPost<T>(Guid id)
    {
        IPostable post = GetThePostFirst();
        if (post.PostType == PostType.Photo) return (Photo)IPostable;
        //etc.
    }
