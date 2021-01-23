    private static string ReplaceWidget(Match match, HtmlHelper helper) {
        var assembly = match.Groups[1].Value;
        var @class = match.Groups[2].Value;
        var serializedParameters = match.Groups[3].Value;
                    
        // Get the type
        var type = Assembly.LoadFrom(HttpContext.Current.Server.MapPath("~/bin/" + assembly)).GetType(@class);
    
        // Deserialize the parameters
        var parameters = JsonConvert.DeserializeObject(HttpUtility.HtmlDecode(serializedParameters), type);
    
        // Return the widget
        return helper.Action("Widget", "Widgets", new { parameters = parameters }).ToString();
    }
