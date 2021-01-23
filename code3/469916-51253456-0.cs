    using (var client = new System.Net.WebClient())
     {
        client.Headers.Add("Accept", "application/json");
        client.Headers.Add("Content-Type", "application/json; charset=utf-8");
        client.DownloadString(...);
     }
