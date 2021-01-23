    async void Run()
    {
        for (int i=0; i<100; i++)
        {
            A();
            await Task.Delay(TimeSpan.FromSeconds(20));
            B();
            await Task.Delay(TimeSpan.FromSeconds(45));
            C();
            await Task.Delay(TimeSpan.FromMinutes(2));
        }
    }
