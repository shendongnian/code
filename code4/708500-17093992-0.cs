    public async Task GetAddress()
    {
        WebApiWorker webApi = new WebApiWorker();
        var geoResponse = await webApi.GetGeocodeAsync("address");
    }
