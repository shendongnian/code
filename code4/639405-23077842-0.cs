    using ( HttpClient http = new HttpClient() )
    {
        var formatter = new JsonMediaTypeFormatter();
        formatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        
        TestDocument value = new TestDocument();
        HttpContent content = new ObjectContent<TestDocument>( value, formatter );
        await http.PutAsync( url, content );
    }
