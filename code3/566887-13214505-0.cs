    public async Task<ActionResult> Index()
    {
        var sw = Stopwatch.StartNew();
        var v1 = GetVideosSlowlyAsync();
        var v2 = GetVideosSlowlyAsync();
        var v3 = GetVideosSlowlyAsync();
        var v4 = GetVideosSlowlyAsync();
        var vm = new AsyncDemoViewModel() {Videos = (await v1).Item2, Messages = new List<string>()};
        sw.Stop();
        vm.Messages.Add(string.Format("Time spent: {0} milliseconds", sw.ElapsedMilliseconds));
        vm.Messages.Add((await v1).Item1);
        vm.Messages.Add((await v2).Item1);
        vm.Messages.Add((await v3).Item1);
        vm.Messages.Add((await v4).Item1);
        return View(vm);
    }
