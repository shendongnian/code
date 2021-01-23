            var parsed = (CarEntity)JsonConvert.DeserializeObject(jsonString, typeof(CarEntity), new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                    Error = ErrorHandler
                });
