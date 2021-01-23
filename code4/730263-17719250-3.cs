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
                listBox1.Items.AddRange(news); //Your code to add items to some control
            },null,TaskScheduler.FromCurrentSynchronizationContext());
    }
