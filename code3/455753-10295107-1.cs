     new Action(() => i++).Unless(i < 1);
     Console.WriteLine(i); // will produce 5
     var isWeatherBad = false;
     var weatherText = "Weather is nice";
     new Action(() => weatherText = "Weather is good!").Unless(isWeatherBad);
     Console.WriteLine(weatherText);
