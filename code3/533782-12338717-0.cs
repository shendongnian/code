    public async Task DoWork() {
    
        int[] ids = new[] { 1, 2, 3, 4, 5 };
        await Task.WhenAll(ids.Select(i => DoSomething(1, i, blogClient)));
    }
