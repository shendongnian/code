    public void Start()
    {
        var worker = new BackgroundWorker();
        worker.DoWork += (sender, args) =>
        {
            GetWeather();
            // put the results of getting the weather in to args.Result
        };
        worker.RunWorkerCompleted += (sender, args) =>
        {
            // use args.Result to update the UI
        };
        worker.RunWorkerAsync();
    }
