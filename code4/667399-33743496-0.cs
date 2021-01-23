        async Task MainRoutine()
        {
            ConcurrentQueue<string> dataQueue = new ConcurrentQueue<string>();
            CancellationTokenSource cts = new CancellationTokenSource();
            Task tRead = ReadAsync(dataQueue);
            Task tWrite = InsertIntoGrid(dataQueue, cts.Token);
            await tRead;
            cts.Cancel();
            await tWrite;
            //Done
        }
        async Task ReadAsync(ConcurrentQueue<string> queue)
        {
            await Task.Run(() =>
            {
                while (!IsEndOfList)
                {
                    string data = //Read data from database/active directory/ ...
                    queue.Enqueue(data);
                }
            });
        }
        async Task InsertIntoGrid(ConcurrentQueue<string> queue, CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    string data;
                    if (queue.TryDequeue(out data))
                    {
                        //insert data to grid
                    }
                    else
                    {
                        await Task.Delay(100);
                    }
                }
            }, cancellationToken);
        }
