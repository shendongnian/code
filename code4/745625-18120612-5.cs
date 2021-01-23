    public void webClient1_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        RootObject root = JsonConvert.DeserializeObject<RootObject>(e.Result);
        JObject obj = root.response.ScoreDetail;
        foreach (KeyValuePair<string, JToken> pair in obj)
        {   
            string key = pair.Key; // here you got 39.
            foreach (JObject detail in pair.Value as JArray)
            {
                string date = detail["test_date"].ToString();
                string score = detail["score"].ToString();
                string total_marks = detail["total_marks"].ToString();
            }
        }
    }
