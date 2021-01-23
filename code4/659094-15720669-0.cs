    public static IObservable<T> DeserializeAsObservable<T>(this TextReader reader)
    {
        var jsonReader = new JsonTextReader(reader);
            
        if (!jsonReader.Read() || jsonReader.TokenType != JsonToken.StartArray)
            throw new Exception();
        var serializer = JsonSerializer.Create(null);
        return Observable.Create<T>(o => 
            {
                while (true)
                {
                    if (!jsonReader.Read())
                        throw new Exception();
                    if (jsonReader.TokenType == JsonToken.EndArray)
                        break;
                    var obj = serializer.Deserialize<T>(jsonReader);
                    o.OnNext(obj);
                }
                o.OnCompleted();
                return (IDisposable)null;
            });
    }
