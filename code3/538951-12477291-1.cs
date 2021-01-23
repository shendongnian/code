    new JsonSerializerSettings
                       {
                           MissingMemberHandling = MissingMemberHandling.Ignore,
                           NullValueHandling = NullValueHandling.Ignore,
                           DefaultValueHandling = DefaultValueHandling.Include,
                           ContractResolver = new JsonConventionResolver(),
                           Converters = new List<JsonConverter>
                                            {
                                                new TwitterDateTimeConverter(),
                                                new TwitterWonkyBooleanConverter(),
                                                new TwitterGeoConverter()
                                            }
                       })
