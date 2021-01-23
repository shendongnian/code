    async Task<string> DoTheThings() {
        Task<Cat> x = FeedCat();
        Task<House> y = FeedCat();
        Task<Tesla> z = FeedCat();
        await Task.WhenAll(x, y, z);
        // presumably we want to do something with the results...
        return DoWhatever(x.Result, y.Result, z.Result)
    }
    
