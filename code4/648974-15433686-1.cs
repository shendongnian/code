    static void filterAllDatas(ref IEnumerable<int> data, IEnumerable<Func<int, bool>> conditions)
    {
        List<int> filteredData = data.ToList();
        List<Task> tasks = new List<Task>();
        foreach (var item in data.AsParallel())
        {
            var i = item;
            foreach (var condition in conditions.AsParallel())
            {
                var c = condition;
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    if (c(i))
                    {
                        filteredData.Remove(i);
                    }
                }));
            }
        }
        Task.WaitAll(tasks.ToArray());
        data = filteredData.AsEnumerable();
    }
