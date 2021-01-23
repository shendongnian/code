    var values = new Dictionary<string, string>();
    values.Add("firstname", "Joe");
    values.Add("lastname", "Average");
    var querystring = String.Join("&", values.Select(pair => 
        pair.Key + "=" + HttpUtility.UrlEncode(pair.Value)).ToArray());
