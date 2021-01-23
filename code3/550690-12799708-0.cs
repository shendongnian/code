    static void Main(string[] args)
    {
        var seq = Enumerable.Range(0, 10).ToList();
        var tasks = seq
            .Select(i => Task.Factory.StartNew(() => Foo(i)))
            .ToList(); // important, spawns the tasks
        var result = tasks.Select(t => t.Result);
        // no results are blockingly received before this
        // foreach loop
        foreach(var r in result)
        {
            Console.WriteLine(r);
        }
    }
    static int Foo(int i)
    {
        return i;
    }
