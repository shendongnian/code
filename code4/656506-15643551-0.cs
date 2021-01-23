    private async Task GetCamera()
    {
       ....
        //tk = new Task(MyAwesomeTask);
        //tk.Start();
        await Task.Run(async () => await MyAwesomeTask());
        ...    
    }
    private async Task MyAwesomeTask()
    {
        while (true)
        {
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            // added await
            await SavePhoto1();
        }
    }
