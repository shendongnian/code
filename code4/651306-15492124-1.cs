    var tasks = new Task<System.Net.WebResponse>[2];
    var urls = new string[] { "http://stackoverflow.com/", "http://google.com/" };
    for (int i = 0; i < tasks.Length; i++)
    {
        var wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(urls[i]);
        tasks[i] = Task.Factory.FromAsync<System.Net.WebResponse>(wr.BeginGetResponse, wr.EndGetResponse, TaskCreationOptions.LongRunning);
    }
    
    var result = Task.Factory.ContinueWhenAll(
        tasks,
        tasklist => {
            foreach (var item in tasklist)
            {
                var resp = item.Result.GetResponseStream();
                // Process responses and combine them into single result
            }
        });
