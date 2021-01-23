     for (int i = 0; i < N; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {               
                     DoThreadStuff(localData);
                });
            }
            while (tasks.Any(t => !t.IsCompleted)) { } //spin wait
