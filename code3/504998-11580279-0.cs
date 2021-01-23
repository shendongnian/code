    for (int i = 0; i < SortedRecommendations.Count; i++)
    {
        string tempfilepath = filepath + SortedRecommendations[i].Aid + ".jpg";
    
        if (File.Exists(tempfilepath))
            continue;
    
        WebClient wc = new WebClient();
        var recommendation = SortedRecommendations[i];
        await wc.DownloadFileTaskAsync(new Uri(recommendation.Image.Replace("t.jpg", ".jpg")), tempfilepath);
        recommendation.Image = tempfilepath;
    }
