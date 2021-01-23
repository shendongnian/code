            int threads = 100;
            Task[] tasks = new Task[threads];
            for (int i = 0; i < threads; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                    {
                        //Dostuffs
                    });
            }
            Task.WaitAll(tasks);
