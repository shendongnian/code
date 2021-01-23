    public PewPew SomeMethod(Foo foo)
    {
        Task<IList<Cat>> catsTask = GetAllTheCatsAsync(foo);
        Task<IList<Food>> foodTask = GetAllTheFoodAsync(foo);
        
        // wait for both tasks to complete
        Task.WaitAll(catsTask, foodTask);
        return new PewPew
        {
            Cats = catsTask.Result,
            Food = foodTask.Result
        };
    }
    public async Task<IList<Cat>> GetAllTheCatsAsync(Foo foo)
    {
        await Task.Delay(7000); // wait for a while
        return new List<Cat>();
    }
    public async Task<IList<Food>> GetAllTheFoodAsync(Foo foo)
    {
        await Task.Delay(5000); // wait for a while
        return new List<Food>();
    }
