    public ActionResult getGrid(string pk, string rk) {
        var ms = new List<long>();
        var sw = Stopwatch.StartNew();
        var vm = new CityDetailViewModel() { MS = ms };
        ...
        ms.Add(sw.ElapsedMilliseconds);
