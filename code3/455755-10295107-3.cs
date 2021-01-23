    int i = 4;
    new Action(() => i++).Unless(i < 5);
    Console.WriteLine(i); // will produce 4
    new Action(() => i++).Unless(i < 1);
    Console.WriteLine(i); // will produce 5
    var isWeatherBad = false;
    var weatherText = "Weather is nice";
    new Action(() => weatherText = "Weather is good!").Unless(isWeatherBad);
    Console.WriteLine(weatherText);
