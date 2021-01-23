    public async Task CreateMap()
    {
        map.Add(mapLayer);
        Dispatcher.BeginInvoke(() =>
                {
                    map.SetView(locationRectangle);
                });
    }
