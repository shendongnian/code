    // WebMethod expects: Dictionary<string, List<Dictionary<string, RoutSerial>>>;
    // Change UseHttpGet to false to send data via HTTP GET.
    [System.Web.Services.WebMethod()]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json, UseHttpGet = false)]
    public static RouteAddedResponse AddRouteData(List<Dictionary<string, RouteSerial>> route)
    {
        // Iterate through the list... 
        foreach (Dictionary<string, RouteSerial> drs in route) {
            foreach (KeyValuePair<string,RouteSerial> rs in drs)
            {
                // Process the routes & data here.. 
                // Route Key:
                // rs.Key;
                // Route Data/Value:
                // rs.Value;
                // ... 
            }
        }
        return new RouteAddedResponse() { id = -1, status = 0, message = "your message here" };
    }
