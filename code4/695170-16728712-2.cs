    public async Task<PewPew> SomeMethod(Foo foo)
    {
        // get the stuff on another thread 
        var cTask = Task.Run(() => GetAllTheCats(foo));
        var fTask = Task.Run(() => GetAllTheFood(foo));
    
        var cats = await cTask;
        var food = await fTask;
    
        return new PewPew
                   {
                       Cats = cats,
                       Food = food
                   };
    }
    
    public IList<Cat> GetAllTheCats(Foo foo)
    {
        // Do stuff, like hit the Db, spin around, dance, jump, etc...
        // It all takes some time.
        return cats;
    }
    
    public IList<Food> GetAllTheFood(Foo foo)
    {
        // Do more stuff, like hit the Db, nom nom noms...
        // It all takes some time.
        return food;
    }
