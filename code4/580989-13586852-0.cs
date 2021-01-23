    public async static Task InitAds(CancellationToken token)
    {
      Debug.WriteLine("API: Loading Ad images");
      await Task.WhenAll(ads.Select(l => l.Value).Where(l=>l!=null).Select(l => l.StartRotation(token)));
    }
