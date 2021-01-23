    public void MyBigWrapperMethod()
    {
        var gpsreadings = new List<TruckGpsReading>();
        foreach (var reading in Reading.GetUnProcessReadings())
        {
            Logging.Log("Starting ProcessGpsFile.ProcessReading 3", "ProcessReading", Apps.RemoteTruckService);
            var gpsreading = new TruckGpsReading();
            gpsreading.DateTimeOfReading = reading.DateTimeOfReading;
            gpsreading.Direction = reading.Direction;
            gpsreading.DriverNumber = CurrentIniSettings.DriverNumber;
            gpsreading.Latitude = (float)reading.Latitude;
            gpsreading.Longitude = (float)reading.Longitude;
            gpsreading.Speed = reading.Speed;
            gpsreading.TruckNumber = CurrentIniSettings.TruckNumber;
            gpsreadings.Add(gpsreading);
        }
        var response = client.SaveGpsReadings(globalSetting.TokenId,
         globalSetting.SourceId, gpsreadings.ToArray());
        if (response == "true")
        {
            // do stuff if it works
        }
        else
        {
            // do stuff if it doesn't work
        }
    }
