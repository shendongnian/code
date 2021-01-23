    public Task GetCurrentPosition()
    {
        return Task.Run(() =>
        {
            if (_geolocator == null)
            {
               _geolocator = new Geolocator { DesiredAccuracy = PositionAccuracy.High };
            }
            Geoposition geoposition = null;
            ManualResetEvent syncEvent = new ManualResetEvent(initialState: false);
            IAsyncOperation asyncOp = _geolocator.GetGeopositionAsync();
 
            asyncOp.Completed += (asyncInfo, asyncStatus) =>
            {
               if (asyncStatus == AsyncStatus.Completed)
               {
                   geoposition = asyncInfo.GetResults();
               }
               syncEvent.Set();
            };
            syncEvent.WaitOne();
            return geoposition.Coordinate;
        });
    }
