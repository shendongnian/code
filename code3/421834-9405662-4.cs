            List<string>[] list = listdbConnect.Select()
            int itemCount = list[0].Count;
            Task[] tasks = new Task[itemCount];
            stopwatch.Start();
            for (int i = 0; i < itemCount; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    // NOTE: Do not use i in here as it is not thread safe to do so! 
                    sendMessage(list[0]['1']);
                    //calling callback function
                });
            }
            // if required you can wait for all tasks to complete
            Task.WaitAll(tasks);
            
            // or for any task you can check its state with properties such as: 
            tasks[1].IsCanceled
            tasks[1].IsCompleted
            tasks[1].IsFaulted 
            tasks[1].Status
