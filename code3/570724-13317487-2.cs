       // code to set up your schema
      // Associate types to their JsonSchemas.  Order matters here.
      // After each parse, the schema is added to resolver, which is used in subsequent parses.
            _schemaTypes = new[]
            {
                Tuple.Create(typeof(Vehicle), "vehicle.schema.json"),
            }
            .ToDictionary(
                x => x.Item1,
                x => JsonSchema.Parse(
                    File.ReadAllText(
                        Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath ?? "",  @"Serialization\Schemas\") + x.Item2),
                        resolver));
     //method to return your deserialized object
     public T Deserialize<T>(IRestResponse response)
        {
            var schema = _schemaTypes[typeof(T)];
            T result = _serializer.Deserialize<T>(
                    new JsonValidatingReader(
                        new JsonTextReader(
                            new StringReader(response.Content)))
                    {
                        Schema = schema
                    });
            return result;
        }
