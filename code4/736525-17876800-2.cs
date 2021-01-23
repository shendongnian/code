    WebClient client = new WebClient();
    client.OpenReadCompleted += (s, e) =>
         {
             byte[] imageBytes = new byte[e.Result.Length];
             e.Result.Write(imageBytes, 0, imageBytes.Length);
         };
    client.OpenReadAsync(new Uri(article.ImageURL));
