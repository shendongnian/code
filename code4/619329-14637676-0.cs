    public static void AddBollingerBands(ref SortedList<DateTime, Dictionary<string, double>> data, int period, int factor)
    {
        double total_average = 0;
        double total_squares = 0;
        for (int i = 0; i < data.Count(); i++)
        {
            total_average += data.Values[i]["close"];
            total_squares += Math.Pow(data.Values[i]["close"], 2);
            if (i >= period - 1)
            {
                double total_bollinger = 0;
                double average = total_average / period;
                double stdev = Math.Sqrt((total_squares - Math.Pow(total_average,2)/period) / period);
                data.Values[i]["bollinger_average"] = average;
                data.Values[i]["bollinger_top"] = average + factor * stdev;
                data.Values[i]["bollinger_bottom"] = average - factor * stdev;
                total_average -= data.Values[i - period + 1]["close"];
            }
        }
    }
