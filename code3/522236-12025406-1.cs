    public class Forecast
    {
        public IEnumerable<ForecastData> Data { get; set; }
    }
    
    public class ForecastData
    {
        public int ForecastID { get; set; }
        public string StatusForecast { get; set; }
    }
