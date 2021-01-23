    public void webClient1_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        var rootObject = JsonConvert.DeserializeObject<RootObject>(e.Result);
        string score = rootObject.response.ScoreDetail.Detail.First().Score;
        string date = rootObject.response.ScoreDetail.Detail.First().TestDate;
        string total = rootObject.response.ScoreDetail.Detail.First().TotalMarks;
    }
