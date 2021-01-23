    List<Task<bool>> tasks = servers.Select(s => Task<bool>.Factory.StartNew(server => CallServer((string)server), s)).ToList();
    bool result;
    do {
        int idx = Task.WaitAny(tasks.ToArray());
        result = tasks[idx].Result;
        tasks.RemoveAt(idx);
    } while (!result && tasks.Count > 0);
    // cancel other tasks
