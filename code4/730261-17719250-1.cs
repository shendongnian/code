    void DisplayNews2()
    {
        Task.Factory.StartNew(() =>
            {
                using (var client = new WebClient())
                {
                    string content = client.DownloadString("http://rapstation.com/webservice.php");
                    return JsonConvert.DeserializeObject<NewsObject[]>(content);
                }
            })
        .ContinueWith((x,y) =>
            {
                NewsObject[] news = x.Result;
               //!!  Your code to add news to some contro
            },null,TaskScheduler.FromCurrentSynchronizationContext());
    }
