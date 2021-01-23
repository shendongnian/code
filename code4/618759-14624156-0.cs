    public async void TestAsync()
    {
        await DoStuffAsync(1);
        await DoStuffAsync(73);
        await Task.WhenAll(DoStuffAsync(2), DoStuffAsync(3));
    }
    public async Task DoStuffAsync(int n)
    {
        await Task.Delay(1000);
        Console.WriteLine("done stuff " + n);
    }
