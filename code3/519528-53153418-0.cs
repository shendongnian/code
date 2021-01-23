    // query example
    //   "name1=value1&name2=value2&name3=value3"
    //   "?name1=value1&name2=value2&name3=value3"
    private Dictionary<string, string> ParseQuery(string query)
    {
        var dic = new Dictionary<string, string>();
        var reg = new Regex("(?:[?&]|^)([^&]+)=([^&]*)");
        var matches = reg.Matches(query);
        foreach (Match match in matches) {
            dic[match.Groups[1].Value] = Uri.UnescapeDataString(match.Groups[2].Value);
        }
        return dic;
    }
