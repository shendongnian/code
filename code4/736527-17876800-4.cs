    WebClient client = new WebClient();
    client.OpenReadCompleted += (s, e) =>
         {
             byte[] imageBytes = new byte[e.Result.Length];
             e.Result.Write(imageBytes, 0, imageBytes.Length);
             // You can now use this stream to set the source of the image
             BitmapImage image = new BitmapImage();
             image.SetSource(e.Result);
             NLBI.Thumbnail.Source = image;
         };
    client.OpenReadAsync(new Uri(article.ImageURL));
