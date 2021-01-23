    Task[] tasks = new Task[mylist.Count];
    int i = 0;
    foreach (DataTable dt in mylist)
    {
        DataTable dtInner = dt;
        Task t = Task.Factory.StartNew(() => UpdateProductsData(dtInner, updateType));
        tasks[i] = t;
        i++;
    }
    Task.WaitAll(tasks);
