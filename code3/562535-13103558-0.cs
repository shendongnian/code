    var weather = ServiceStack.Text.JsonSerializer.DeserializeFromString<RootWeather>(content);
    public class RootWeather
    {
        public Weather data { get; set; }
    }
    public class Weather
    {
        public List<NearestArea> nearest_area { get; set; }
    }
    public class NearestArea
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string distance_miles { get; set; }
    }
