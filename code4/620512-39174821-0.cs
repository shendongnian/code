    using System.Collections.Async;
    
    public async void getThreadContents(String[] threads)
    {
        HttpClient client = new HttpClient();
        List<String> usernames = new List<String>();
        int i = 0;
    
        await threads.ParallelForEachAsync(async url =>
        {
            i++;
            progressLabel.Text = "Scanning thread " + i.ToString() + "/" + threads.Count<String>();
            HttpResponseMessage response = await client.GetAsync(url);
            String content = await response.Content.ReadAsStringAsync();
            String user;
            Predicate<String> userPredicate;
            foreach (Match match in regex.Matches(content))
            {
                user = match.Groups[1].ToString();
                userPredicate = (String x) => x == user;
                if (usernames.Find(userPredicate) != user)
                {
                    usernames.Add(match.Groups[1].ToString());
                }
            }
            
            // THIS CALL MUST BE THREAD-SAFE!
            progressBar1.PerformStep();
        },
        maxDegreeOfParallelism: 8);
    }
