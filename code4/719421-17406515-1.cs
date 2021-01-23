    public int GetValue()
    {
        List<Task<int>> tasks = new List<Task<int>>();
        for (int i = 0; i <=5; i++)
        {
            tasks.Add(PasswdThread(i));
        }
        Task.WaitAll(tasks);
        // You can now query all the tasks:
        foreach (int result in tasks.Select(t => t.Result))
        { 
            if (result == 100) // Do something to pick the desired result...
            {
                return result;
            }
        }
        return -1;
    }
    public Task<int> PasswdThread(int i)
    {
        return Task.Factory.StartNew(() => {
            Thread.Sleep(1000);
            Random r=new Random();
            int n=r.Next(10);
            if (n==5)
            {
                return r.Next(1000);
            }
            return 0;
        });
    }
