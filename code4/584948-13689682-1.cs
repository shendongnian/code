      public async Task<string>getData()
           {
              HttpClient client=new HttpClient();
        String URL="your string";//url for the JSON response
        HttpResponseMessage response=await client.GetAsync(URL);
        Return await response.Content.ReadAsStringAsync();
        }
        
       private void async Button1_click ()
       {
          string responseText= await getData();
    DataContractJsonSerializer= new DataContractJsonSerializer(typeOf(RootObject));//DataContractJsonSerializer is the class object that u will generate 
    RootObject root;
    Using(MemoryStream stream=new MemoryStream(Encoding.Unicode.GetBytes(responseText)))
    {
        //access properties here
    }
    }
