     static async void Main()
    	{
            try	
               {
          // Create a New HttpClient object.
          HttpClient client = new HttpClient();
    
          HttpResponseMessage response = await client.PostAsync("https://www.abcd.com/ws/transaction/createTransaction");
          response.EnsureSuccessStatusCode();
          string responseBody = await response.Content.ReadAsStringAsync();
          // Above three lines can be replaced with new helper method in following line 
          // string body = await client.GetStringAsync(uri);
    
          Console.WriteLine(responseBody);
        }  
        catch(HttpRequestException e)
        {
          Console.WriteLine("\nException Caught!");	
          Console.WriteLine("Message :{0} ",e.Message);
        }
      }
