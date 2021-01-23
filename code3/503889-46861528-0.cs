    var jss = new JsonSerializerSettings
        {
             DateFormatHandling = DateFormatHandling.IsoDateFormat,
             DateTimeZoneHandling = DateTimeZoneHandling.Local, 
             DateParseHandling = DateParseHandling.DateTimeOffset
        };
    var responseObj = JsonConvert.DeserializeObject<dynamic>(body, jss);
    return responseObj.Select(s => new {
                        id = s["id"].Value<int>(),
                        date = s["date"].Value<DateTimeOffset>().DateTime,
                    });
