    var forecasts = new List<WeatherForecast>();
    foreach(var line in File.ReadLines(file))
    {
        var values = line.Split(" ");
        forecasts.Add(new WeatherForecast
                          {
                              Outlook = values[0],
                              Temperature = values[1],
                              Humidity = values[2],
                              Windy = Convert.ToBoolean(values[3]),
                              PlayTennis = values[4]
                          });
    }
