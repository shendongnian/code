    config.Routes.MapHttpRoute(
                name: "GetByCoordinatesRoute",
                routeTemplate: "/GetByCoordinatesRoute/{*coords}",
                defaults: new { controller = "MyController", action = "GetByCoordinatesRoute" }
    public ActionResult GetByCoordinatesRoute(string coords)
    {
        int[][] coordArray = RegEx.Matches("\[(\d+),(\d+)\]")
                                  .Cast<Match>()
                                  .Select(m => new int[] 
                                          {
                                              Convert.ToInt32(m.Groups[1].Value),
                                              Convert.ToInt32(m.Groups[2].Value)
                                          })
                                  .ToArray();
    }
