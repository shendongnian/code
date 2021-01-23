    Task<string>[] tableOfWebClientTasks = new Task<string>[taskCount];
    var taskIdToUrl = new Dictionary<int,string>();
    for (int i = 0; i < taskCount; i++)
    {
        var url = allUrls[count - i - 1];
        var task = new WebClient().DownloadStringTask(url);
        tableOfWebClientTasks[i] = task;
        taskIdToUrl.Add(task.Id, url);
    }
    TaskFactory.ContinueWhenAll(tableOfWebClientTasks, tasks =>
    {
        Parallel.ForEach(tasks, task =>
        {
            // To get the url just do:
            var url = taskIdToUrl[task.Id];
        });
    });
