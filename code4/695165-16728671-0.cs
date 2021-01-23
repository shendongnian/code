    public PewPew SomeMethod(Foo foo)
    {
        Task<IList<Cat>> catsTask = GetAllTheCats(foo);
        Task<IList<Food>> foodTask = GetAllTheFood(foo);
        Task.WaitAll(catsTask, foodTask);
        return new PewPew
        {
            Cats = catsTask.Result,
            Food = foodTask.Result
        };
    }
    public async Task<IList<Cat>> GetAllTheCats(Foo foo)
    {
        await Task.Delay(7000); // wait for a while
        return new List<Cat>();
    }
    public async Task<IList<Food>> GetAllTheFood(Foo foo)
    {
        await Task.Delay(5000); // wait for a while
        return new List<Food>();
    }
