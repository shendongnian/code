    public void jsonHome_GetDataCompleted(object snder, DownloadStringCompletedEventArgs e)
    {
        NewReleasesCharts homeData = JsonConvert.DeserializeObject<NewReleasesCharts>(e.Result);
        const int limit = 4;
        this.listRelease.ItemsSource = homeData.results.featuredReleases.Take(limit);
    }
