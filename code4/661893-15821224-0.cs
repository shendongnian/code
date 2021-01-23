    public string GetResponse()
    {            
        HttpWebResponse response = session.Request().Get().ForUrl(url).
            SignWithoutToken().
            WithQueryParameters(new { start_time = 1364962612, end_time = 1364991412  }).
            ToWebResponse();
        var result = GetWebResponseAsString(response);
        return result;
    }
