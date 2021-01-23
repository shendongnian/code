    void DisplayPrimesCount()
    {
        var awaiter = GetPrimesCountAsync(2, 100000).GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            int result = awaiter.GetResult();
            Console.WriteLine(result);
        });
    }
