    Task<string> DoTheThings() {
        Task<Cat> x = FeedCat();
        Task<House> y = SellHouse();
        Task<Tesla> z = BuyCar();
    
        if(x.Status == TaskStatus.RanToCompletion &&
           y.Status == TaskStatus.RanToCompletion &&
           z.Status == TaskStatus.RanToCompletion)
            return Task.FromResult(
              DoWhatever(a.Result, b.Result, c.Result));
           // we can safely access .Result, as they are known
           // to be ran-to-completion
        return Awaited(x, y, z);
    }
    async Task Awaited(Task<Cat> a, Task<House> b, Task<Tesla> c) {
        return DoWhatever(await x, await y, await z);
    }
