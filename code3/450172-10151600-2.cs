    ...
    var rowHandler1 = new MyRowHandler();
    rowHandler1.ido = shared.ObserveOn(Scheduler.NewThread).Subscribe(rowHandler1.ProcessID);
    ...
    public void ProcessID(int i)
    {
        Console.WriteLine(String.Format("Start Thread ID {0} Int{1}", Thread.CurrentThread.ManagedThreadId, i));
        Thread.Sleep(30);
        Console.WriteLine("Done Thread ID" + Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture));
    }
