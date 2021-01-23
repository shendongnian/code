    MAX_THREAD_ALLOWED = 100;
    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(Task.Run(() => { Foo(i); }));
        if (i == MAX_THREAD_ALLOWED)
        {
            Task.WaitAny(tasks.ToArray());
            MAX_THREAD_ALLOWED++;
        }
    }
