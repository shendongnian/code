    int[] results = new int[tasks.Length];
    for (int i = 0; i < tasks.Length; i++)
    {
        if (tasks[i].IsCompleted)
        {
            Console.WriteLine(tasks[i].Result);
        }
    }
