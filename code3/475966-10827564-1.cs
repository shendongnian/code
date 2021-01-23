    private IEnumerable<MyItem> ReadLinesFromFile(string fileName)
    {
        var source = from e in Enumerable.Range(1, 20)
                     let v = e.ToString()
                     select v;
        foreach (var item in source)
        {
            Thread.Sleep(1000);
            yield return new MyItem { CurrentThread = Thread.CurrentThread.ManagedThreadId, Line = item };
        }
    }
    private MyItem UpdateResultToDatabase(string processedLine)
    {
        Thread.Sleep(700);
        return new MyItem { Line = "s" + processedLine, CurrentThread = Thread.CurrentThread.ManagedThreadId };
    }
    private MyItem ProcessLine(string line)
    {
        Thread.Sleep(4000);
        return new MyItem { Line = "p" + line, CurrentThread = Thread.CurrentThread.ManagedThreadId };
    }
