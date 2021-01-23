    public void InitSomeDataForSerialization()
    {
        Longitude = 10; Latitude = 4; Notes = "Test";
        
        DailyData.Add(
            new ClimateDailyData { DataDate = DateTime.Today, MinTemperature = 12, MaxTemperature = 35}
        );
    }
