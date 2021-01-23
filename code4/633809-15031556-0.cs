            List<Task> tasks = new List<Task>();
            while (condition)
            {
                if (true)
                {                    
                    Task temp = Task.Factory.StartNew(() => 0);
                    tasks.Add(temp);
                }
                //...
            }
            Task.WaitAll(tasks.ToArray());
