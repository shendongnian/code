    var obj = JsonConvert.DeserializeObject(json, type, new JsonSerializerSettings {
        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
        DateTimeZoneHandling = DateTimeZoneHandling.Local,
        Converters = new JsonConverter[] { new MY_CUSTOM_CONVERTER() }
    });
