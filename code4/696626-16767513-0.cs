    public void Start()
    {
        var yourTasks = new Task[] {
        Task.Factory.StartNew(_ => task1(),
        Task.Factory.StartNew(_ => task2(),
        Task.Factory.StartNew(_ => ...
        Task.Factory.StartNew(_ => taskN() };
        Task.WaitAll(yourTasks ); // wait for all N tasks to complete
        Start();
    }
