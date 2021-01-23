    string input;      // Your input string
    List<string> outputs = new List<string>();
    // Parse the original string
    NameValueCollection parms = HttpUtility.ParseQueryString(input);
    // Loop over each item, url encoding
    foreach (string key in parms.AllKeys)  {
        foreach (string val in parms.GetValues(key))
            outputs.Add(HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(val));
    }
    // combine the encoded strings, joining with &
    string result = string.Join("&", outputs);    // the final result
