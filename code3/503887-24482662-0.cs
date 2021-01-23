    microsoftDateFormatSettings = new JsonSerializerSettings
                    {
                        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.Local
                    };
     var   items = JsonConvert.DeserializeObject<List<lstObject>>(jsonString, microsoftDateFormatSettings);
