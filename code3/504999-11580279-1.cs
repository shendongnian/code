    for (int i = 0; i < SortedRecommendations.Count; i++)
    {
        string tempfilepath = filepath + SortedRecommendations[i].Aid + ".jpg";
    
        if (File.Exists(tempfilepath))
            continue;
    
        WebClient wc = new WebClient();
        var recommendation = SortedRecommendations[i];
        var downloadTask = wc.DownloadFileTaskAsync(new Uri(recommendation.Image.Replace("t.jpg", ".jpg")), tempfilepath);
        var continuation = downloadTask.ContinueWith(t => recommendation.Image = tempfilepath);
        tasks.Add(continuation);
    }
    await Task.WhenAll(tasks);
