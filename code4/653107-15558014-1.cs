    private static readonly ActionBlock<Message<int>> Block =
        new ActionBlock<Message<int>>(
            x => Inc(x),
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = 3
            });
    static void Inc(Message<int> input)
    {
        Thread.Sleep(100);
        input.TCS.SetResult(input.Data + 1);
    }
    // operation contract
    public async Task Inc(int id)
    {
        var tcs = new TaskCompletionSource<int>();
        Block.Post(new Message<int> { TCS = tcs, Data = id });
        int result = await tcs.Task;
        // do further processing using initiator service instance members
        // something like Callback.IncResult(result);
    }
