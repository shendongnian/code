    private async Task DoStuff()
    {
         await Task.Delay(5000);
        //or drop the async modifier and 'return Task.Delay(5000);'
    }
    public async void Execute(object parameter)
    {
        await DoStuff();
        //Add some checks if it really was 'OK', catch exceptions etc
        Name = "OK";
    }
