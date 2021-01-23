    public class MainRoute {
            public int RouteNumber { get; set; }
            public IList<SubRoute> SubRoutes { get; set; }
    
            public MainRoute()
            {
                    SubRoutes = new List<SubRoute>();
            }
    }
    
    public class SubRoute {
            public int RouteNumber { get; set; }
            public string StopName { get; set; }
            public int Route { get; set; }
    
            [JsonProperty("date")]
            public string Date { get; set; }
    
            [JsonProperty("day")]
            public string Day { get; set; }
            public int Direction { get; set; }
    
            [JsonProperty("DateCalender")]
            public string DateCalendar { get; set; }
    }
    
    class Program {
            static void Main(string[] args)
            {
                    string jsonString = FetchJsonData();
                    var routes = ParseRouteJsonString(jsonString);
            }
    
            static IEnumerable<MainRoute> ParseRouteJsonString(string jsonString)
            {
                    JObject jsonObject = JObject.Parse(jsonString);
                    foreach (KeyValuePair<string, JToken> pair in jsonObject) {
                            var mainRoute = new MainRoute() {
                                    RouteNumber = Int32.Parse(pair.Key) // Get main route number.
                            };
    
                            foreach (JProperty property in pair.Value) {
                                    var subRoute = property.Value.ToObject<SubRoute>();
                                    subRoute.RouteNumber = Int32.Parse(property.Name); // Get sub route number.
                                    mainRoute.SubRoutes.Add(subRoute);
                            }
    
                            yield return mainRoute;
                    }
            }
    }
