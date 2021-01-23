     var model = new MyModel(); 
     using (var client = new HttpClient())
     {
         var uri = new Uri("XXXXXXXXX"); 
         var json = new JavaScriptSerializer().Serialize(model);
         var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
         var response = await Client.PutAsync(uri,stringContent).Result;
         ...
         ...
      }
