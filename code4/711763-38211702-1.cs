    public async Task DoSomething()
    {
        IsBusy = true;
        await _myService.LongRunningProcess();
        IsBusy = false;
    }
