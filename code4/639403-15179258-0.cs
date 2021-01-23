    public static HttpResponseMessage InsertDocument(object doc, string name, string db)
        {
          HttpResponseMessage result;
          string json = JsonConvert.SerializeObject(doc, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
          if (String.IsNullOrWhiteSpace(name)) result = clientSetup().PostAsync(db, new StringContent(json)).Result;
          else result = clientSetup().PutAsync(db + String.Format("/{0}", name), new StringContent(json)).Result;
          return result;
        }
    
