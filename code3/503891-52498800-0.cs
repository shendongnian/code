    var serializerSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local
                };
                var serializer = JsonSerializer.Create(serializerSettings);
