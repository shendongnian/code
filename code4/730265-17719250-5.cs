    void DisplayNews2()
    {
        string url = "http://rapstation.com/webservice.php";
        Task.Factory.StartNew(() =>
            {
                using (var client = new WebClient())
                {
                    string content = client.DownloadString(url);
                    return JsonConvert.DeserializeObject<NewsObject[]>(content);
                }
            })
        .ContinueWith((task,y) =>
            {
                NewsObject[] news = task.Result;
                //!! Your code to add news to some control
            },null,TaskScheduler.FromCurrentSynchronizationContext());
    }
