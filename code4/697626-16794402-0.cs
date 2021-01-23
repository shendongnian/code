    public async Task<Bar> GenerateFoo()
    {
        await Task.Delay(1000);
        return new Bar() { Name = i.ToString() };
    }
    public IEnumerable<Task<Bar>> GetBars()
    {
        for(int i = 0; i < 1000; i++)
        {
            yield return GenerateFoo();
        }
    }
