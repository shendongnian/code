    public async Task ProcessData(IEnumerable<int> data)
    {
        var tasks = new List<Task>();
        using (var disp = new CompositeDisposable())
        {
            foreach (var d in data)
            {
                var processor = new Processor(d);
                disp.Add(processor);
                processor.Completed += (sender, e) =>
                    {
                        // Do something else
                    };
                tasks.Add(processor.ProcessAsync());
            }
            await Task.WhenAll(tasks);
        }
    }
