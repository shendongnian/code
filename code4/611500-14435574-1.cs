    using (var client = new HttpClient())
    {
        var response = client.GetAsync("http://google.com").Result;
        
        if (response.IsSuccessStatusCode)
        {
            // by calling .Result you are performing a synchronous call
            var responseContent = response.Content; 
            // by calling .Result you are synchronously reading the result
            string responseString = responseContent.ReadAsStringAsync().Result;
            Console.WriteLine(responseString);
        }
    }
