    public FullResult GetResult(int id)
    {
        Request1 req = new Request1();
        req.id = id;
        Request2 req2 = new Request2();
        req2.id = id;
        var tasks = new Task[] {
            Task.Factory.StartNew(() => Func1(req))
            , Task.Factory.StartNew(() => Func2(req2))};
        System.Threading.Tasks.Task.WaitAll(tasks);
        FullResult result = new FullResult();
        result.first = tasks[0];
        result.second = tasks[1];
        return result;
    }
