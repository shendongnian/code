    static ConsoleKeyInfo? MyReadKey()
    {
        var task = Task.Run(() => Console.ReadKey(true));
        bool read = task.Wait(1000);
        if (read) return task.Result;
        return null;
    }
---
    var key = MyReadKey();
    if (key == null)
    {
        Console.WriteLine("NULL");
    }
    else
    {
        Console.WriteLine(key.Value.Key);
    }
