    [Test]
    public void TaskRun()
    {
        Console.WriteLine("Before");
        var task = Task.Run(() => Console.WriteLine(_terminator.IWillBeBack()));
        Console.WriteLine("After");
        task.Wait();
    }
