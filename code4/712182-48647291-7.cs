    Task DoTheThings() {
        Task<Cat> x = FeedCat();
        Task<House> y = FeedCat();
        Task<Tesla> z = FeedCat();
    
        if(x.Status == TaskStatus.RanToCompletion &&
           y.Status == TaskStatus.RanToCompletion &&
           z.Status == TaskStatus.RanToCompletion)
           return Task.CompletedTask; // synchronous path
    
        return Awaited(x, y, z);
    }
