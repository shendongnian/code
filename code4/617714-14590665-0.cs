    static async void Main()
    	{
        try	
        {
          // Create a New HttpClient object.
          HttpClient client = new HttpClient();
        
          string requestUrl = "https://api.paymo.biz/service/paymo.auth.logout?api_key=API_KEY&format=JSON&auth_token=AUTH_TOKEN"
          HttpResponseMessage response = await client.GetAsync(requestUrl );
          response.EnsureSuccessStatusCode();
          string responseBodyJSON = await response.Content.ReadAsStringAsync();
          // Above three lines can be replaced with new helper method in following line 
          // string body = await client.GetStringAsync(uri);
    
          Console.WriteLine(responseBodyJSON );
          // Now you can start parsing your JSON....
        }  
        catch(HttpRequestException e)
        {
          Console.WriteLine("\nException Caught!");	
          Console.WriteLine("Message :{0} ",e.Message);
        }
      }
