        //codes in your PostService which implements IPostService
        [CacheEvent("POST")]
        [Transaction]
        public void Save(Post post) //care about domain model instead of view model
        {
           // Save.
           _postReposity.Save(post);
        }
