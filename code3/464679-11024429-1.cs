    static void TweetWithMediaDemo(TwitterContext twitterCtx)
    {
        string status = "Testing TweetWithMedia #Linq2Twitter " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
        const bool possiblySensitive = false;
        const decimal latitude = StatusExtensions.NoCoordinate; //37.78215m;
        const decimal longitude = StatusExtensions.NoCoordinate; // -122.40060m;
        const bool displayCoordinates = false;
        const string replaceThisWithYourImageLocation = @"..\..\images\200xColor_2.png";
        var mediaItems =
            new List<Media>
            {
                new Media
                {
                    Data = Utilities.GetFileBytes(replaceThisWithYourImageLocation),
                    FileName = "200xColor_2.png",
                    ContentType = MediaContentType.Png
                }
            };
        Status tweet = twitterCtx.TweetWithMedia(
            status, possiblySensitive, latitude, longitude, 
            null, displayCoordinates, mediaItems, null);
        Console.WriteLine("Media item sent - Tweet Text: " + tweet.Text);
    }
