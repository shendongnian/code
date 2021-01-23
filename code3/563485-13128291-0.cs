    public void DoSomething(string text)
    {
        Task<int> task = Task.Run(() => text.Length);
        ...
    }
