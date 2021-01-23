    var bodyContent = JsonConvert.SerializeObject(apicallObject); // model name
    using (HttpClient client = new HttpClient())
    {
     var content = new StringContent(bodyContent.ToString(), Encoding.UTF8, 
     "application/json");
     content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
     client.DefaultRequestHeaders.Add("access-token", this._token); // _token - 
     authorization token
     var response = await client.PostAsync(url, content); //url -api endpoint url
     if (response != null)
     {
        var jsonString = await response.Content.ReadAsStringAsync();
        try
     {
     var result = JsonConvert.DeserializeObject<model>(jsonString); // model - json 
     Deserialize model
     }
     catch (Exception e)
     {
      //msg
      throw e;
     }
    }
   }
